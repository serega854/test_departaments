using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;




namespace WinFormsApp5
{
    public partial class DepartmentForm : Form
    {
        private static readonly ILogger Logger = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
               .AddFile("../Logs/mylog-{Date}.txt"); //bin/Debig/logs

           
        }).CreateLogger<DepartmentForm>();



        private List<Employee> employeesOnSelectedPosition;
        private int currentEmployeeIndex = 0;
        public DepartmentForm()
        {
            InitializeComponent();
            select_click(this, EventArgs.Empty);
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            select_click(sender, e);
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        public async void select_click(object sender, EventArgs e)
        {
            try
            {
                DepartmentRepository departmentRepository = new DepartmentRepository(new AppDbContext());
                List<Department> departments = await departmentRepository.GetAllDepartmentsAsync();

                treeView1.Nodes.Clear(); // Очистить существующие узлы

                // Словарь для быстрого доступа к узлам по их Id
                Dictionary<int, TreeNode> nodeDictionary = new Dictionary<int, TreeNode>();

                // Создание узлов для каждого департамента
                foreach (var department in departments)
                {
                    TreeNode departmentNode = new TreeNode(department.Name);
                    departmentNode.Tag = department; // Сохранить объект Department в Tag для последующего использования
                    nodeDictionary.Add(department.DepartmentId, departmentNode);

                    // Получить все должности для данного департамента
                    PositionRepository positionRepository = new PositionRepository(new AppDbContext());
                    List<Position> positions = await positionRepository.GetPositionsByDepartmentIdAsync(department.DepartmentId);

                    // Создание узлов для каждой должности
                    foreach (var position in positions)
                    {
                        TreeNode positionNode = new TreeNode(position.Title);
                        positionNode.Tag = position; // Сохранить объект Position в Tag для последующего использования
                        departmentNode.Nodes.Add(positionNode);
                    }

                    // Если у департамента есть родительский департамент, добавить его как дочерний узел
                    if (department.ParentDepartmentId.HasValue && nodeDictionary.ContainsKey(department.ParentDepartmentId.Value))
                    {
                        TreeNode parentNode = nodeDictionary[department.ParentDepartmentId.Value];
                        parentNode.Nodes.Add(departmentNode);
                    }
                    else
                    {
                        // В противном случае, если у департамента нет родительского департамента, добавить его как корневой узел
                        treeView1.Nodes.Add(departmentNode);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при выполнении запроса к базе данных: {ex.Message}");
            }
        }

        private void OpenEmployeesForm()
        {
            // Проверяем, является ли выбранный узел узлом, соответствующим должности
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is Position)
            {
                Position selectedPosition = (Position)treeView1.SelectedNode.Tag;
                EmployeesForm employeesForm = new EmployeesForm(selectedPosition);
                employeesForm.Show();
                Logger.LogInformation("Пользователь открыл форму сотрудников");
            }
        }

        

        private void sel_Click(object sender, EventArgs e)
        {
            OpenEmployeesForm();
            ClearFormData();
        }

        private void select_person2(object sender, EventArgs e)
        {
            OpenEmployeesForm();

        }


        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is Department)
                {
                    int parentDepartmentId = ((Department)treeView1.SelectedNode.Tag).DepartmentId;
                    AddBranch updateBranchForm = new AddBranch(parentDepartmentId, this);
                    updateBranchForm.ShowDialog();
                    Logger.LogInformation("Добавлен новый элемент");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при добавлении элемента: {ex.Message}");
            }
        }



        private void upt_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode != null)
                {
                    TreeNode selectedNode = treeView1.SelectedNode;
                    int parentDepartmentId = -1; //  не используем этот параметр при редактировании поэтому передаем -1
                    UpdateBranch updateBranchForm = new UpdateBranch(parentDepartmentId, this, selectedNode);
                    updateBranchForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при открытии формы редактирования ветки: {ex.Message}");
                MessageBox.Show($"Произошла ошибка при открытии формы редактирования ветки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Logger.LogInformation("Форма редактирования ветки успешно открыта.");
        }


        private async void del_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode != null)
                {
                    if (treeView1.SelectedNode.Tag is Department)
                    {
                        Department selectedDepartment = (Department)treeView1.SelectedNode.Tag;
                        using (var departmentRepository = new DepartmentRepository(new AppDbContext()))
                        {
                            await departmentRepository.DeleteDepartmentAsync(selectedDepartment.DepartmentId);
                        }
                    }
                    else if (treeView1.SelectedNode.Tag is Position)
                    {
                        Position selectedPosition = (Position)treeView1.SelectedNode.Tag;
                        using (var positionRepository = new PositionRepository(new AppDbContext()))
                        {
                            await positionRepository.DeletePositionAsync(selectedPosition.PositionId);
                        }
                    }
                    select_click(this, EventArgs.Empty); // Обновляем данные на форме
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при удалении ветки: {ex.Message}");
                MessageBox.Show($"Произошла ошибка при удалении ветки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Logger.LogInformation("Ветка успешно удалена.");
        }






        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }

        private void DepartmentForm_Load_1(object sender, EventArgs e)
        {

        }








        private async void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            info.Text = "";
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is Position)
            {
                Position selectedPosition = (Position)treeView1.SelectedNode.Tag;
                using (var dbContext = new AppDbContext())
                {
             
                    await LoadEmployeesForSelectedPosition(selectedPosition.PositionId);
                    currentEmployeeIndex = 0; // Сброс индекса при выборе новой должности
                    DisplayCurrentEmployee();
                    int employeeCount = await dbContext.Employees.CountAsync(e => e.PositionId == selectedPosition.PositionId);
                    info.Text = $"На этой должности: {employeeCount} сотрудников";
                }
            }
        }


        private async Task LoadEmployeesForSelectedPosition(int positionId)
        {
            using (var dbContext = new AppDbContext())
            {
                employeesOnSelectedPosition = await dbContext.Employees.Where(e => e.PositionId == positionId).ToListAsync();
            }
        }

        private void DisplayCurrentEmployee()
        {
            if (employeesOnSelectedPosition != null && employeesOnSelectedPosition.Count > 0)
            {
                Employee currentEmployee = employeesOnSelectedPosition[currentEmployeeIndex];
                textBox1.Text = currentEmployee.LastName;
                textBox2.Text = currentEmployee.FirstName;
                textBox3.Text = currentEmployee.MiddleName;
                dateTimePicker1.Value = currentEmployee.HireDate;
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (employeesOnSelectedPosition != null && currentEmployeeIndex > 0)
            {
                currentEmployeeIndex--;
                DisplayCurrentEmployee();
            }
        }

        private async void to_Click(object sender, EventArgs e)
        {
            if (employeesOnSelectedPosition != null && currentEmployeeIndex < employeesOnSelectedPosition.Count - 1)
            {
                currentEmployeeIndex++;
                DisplayCurrentEmployee();
            }
        }






        public void ClearFormData()
        {
            treeView1.SelectedNode = null; // Очистить выбранный узел в treeView1
                                           // Очистка текстовых полей
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            info.Text = "";
        }

        

        // Обработчик события нажатия кнопки "Очистить"
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearFormData();
        }

    }
}

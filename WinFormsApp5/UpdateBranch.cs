using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class UpdateBranch : Form
    {
        public enum BranchType
        {
            Department,
            Position
        }

        private static readonly ILogger Logger = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .AddFile("../Logs/mylog-{Date}.txt"); //bin/Debug/logs

        }).CreateLogger<UpdateBranch>();

        public UpdateBranch(int parentDepartmentId, DepartmentForm departmentForm, TreeNode selectedNode)
        {
            InitializeComponent();
            this.parentDepartmentId = parentDepartmentId;
            this.departmentForm = departmentForm;
            this.selectedNode = selectedNode;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            // Добавляем элементы в комбобокс
            comboBox1.Items.Add("Подразделение");
            comboBox1.Items.Add("Должность");

            // Блокируем комбобокс
            comboBox1.Enabled = false;
        }


        private async void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, выбрана ли какая-либо ветка
                if (selectedNode != null)
                {
                    // Если ветка выбрана и это подразделение
                    if (selectedNode.Tag is Department)
                    {
                        Department selectedDepartment = (Department)selectedNode.Tag;

                        // Изменяем название подразделения
                        selectedDepartment.Name = textBox1.Text;

                        // Сохраняем изменения в базе данных
                        using (var departmentRepository = new DepartmentRepository(new AppDbContext()))
                        {
                            await departmentRepository.UpdateDepartmentAsync(selectedDepartment);
                        }
                    }
                    // Если ветка выбрана и это должность
                    else if (selectedNode.Tag is Position)
                    {
                        Position selectedPosition = (Position)selectedNode.Tag;

                        // Изменяем название должности
                        selectedPosition.Title = textBox1.Text;

                        // Сохраняем изменения в базе данных
                        using (var positionRepository = new PositionRepository(new AppDbContext()))
                        {
                            await positionRepository.UpdatePositionAsync(selectedPosition);
                        }
                    }

                    // Обновляем данные на главной форме
                    departmentForm.select_click(this, EventArgs.Empty);

                    // Закрываем форму редактирования ветки
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Логируем ошибку
                Logger.LogError($"Ошибка при редактировании ветки: {ex.Message}");
                MessageBox.Show($"Произошла ошибка при редактировании ветки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateBranch_Load(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, выбрана ли какая-либо ветка
                if (selectedNode != null)
                {
                    // Если ветка выбрана, извлекаем объект Department из Tag выбранной ветки
                    if (selectedNode.Tag is Department)
                    {
                        Department selectedDepartment = (Department)selectedNode.Tag;

                        // Заполняем текстовое поле названием департамента
                        textBox1.Text = selectedDepartment.Name;

                        // Устанавливаем тип ветки как подразделение (Department)
                        comboBox1.SelectedIndex = (int)BranchType.Department;
                    }
                    // Если ветка выбрана, и это должность (Position)
                    else if (selectedNode.Tag is Position)
                    {
                        Position selectedPosition = (Position)selectedNode.Tag;

                        // Заполняем текстовое поле названием должности
                        textBox1.Text = selectedPosition.Title;

                        // Устанавливаем тип ветки как должность (Position)
                        comboBox1.SelectedIndex = (int)BranchType.Position;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при загрузке данных о ветке: {ex.Message}");
                MessageBox.Show($"Произошла ошибка при загрузке данных о ветке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int parentDepartmentId;
        private DepartmentForm departmentForm;
        private TreeNode selectedNode;
    }
}

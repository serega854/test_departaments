using Microsoft.EntityFrameworkCore;
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
    public partial class EmployeesForm : Form
    {
        private readonly Position _selectedPosition;

        // Добавляем свойство SelectedPosition для доступа из других классов
        public Position SelectedPosition => _selectedPosition;
        private readonly IEmployeeRepository employeeRepository;

        private static readonly ILogger Logger = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .AddFile("../Logs/EmployeesForm-{Date}.txt");

            
        }).CreateLogger<EmployeesForm>();

        public EmployeesForm(Position selectedPosition)
        {
            InitializeComponent();

            _selectedPosition = selectedPosition;
            employeeRepository = new EmployeeRepository(new AppDbContext()); // Создание экземпляра employeeRepository
                                                                             // Растягиваем столбцы DataGridView на всю ширину доступной области
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Загрузка данных о работниках для выбранной должности
            LoadEmployees(selectedPosition);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Empliyees_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Empliyees_Load_1(object sender, EventArgs e)
        {

        }

        // Обработчик события FormClosed для формы updateEmployees
        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadEmployees(_selectedPosition);
        }


        private void uptButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что хотя бы одна строка выбрана в DataGridView и она содержит данные
                if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Cells["LastNameColumn"].Value != null)
                {
                    // Получаем данные выбранной строки
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    string lastName = selectedRow.Cells["LastNameColumn"].Value.ToString();
                    string firstName = selectedRow.Cells["FirstNameColumn"].Value.ToString();
                    string middleName = selectedRow.Cells["MiddleNameColumn"].Value.ToString();
                    DateTime hireDate = (DateTime)selectedRow.Cells["HireDateColumn"].Value;

                    // Создаем новый экземпляр формы updateEmployees
                    updateEmployees updateForm = new updateEmployees(lastName, firstName, middleName, hireDate);

                    // Подписываемся на событие DataUpdated
                    updateForm.DataUpdated += UpdateForm_DataUpdated;

                    // Отображаем форму
                    updateForm.Show();
                }
                else
                {
                    MessageBox.Show("Выберите строку в таблице для редактирования или заполните пустую строку.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при обновлении данных работника: {ex.Message}");
                MessageBox.Show($"Произошла ошибка при редактировании данных работника: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedPosition != null)
                {
                    // Создаем экземпляр репозитория сотрудников
                    AppDbContext dbContext = new AppDbContext();

                    // Создаем экземпляр репозитория сотрудников, передавая объект контекста
                    IEmployeeRepository employeeRepository = new EmployeeRepository(dbContext);

                    // Создаем экземпляр формы AddEmployees, передавая идентификатор должности и репозиторий
                    AddEmployees addEmployeesForm = new AddEmployees(_selectedPosition.PositionId, employeeRepository);

                    // Устанавливаем текущую форму как владельца для AddEmployees
                    addEmployeesForm.Owner = this;
                    addEmployeesForm.Show();
                }
                else
                {
                    MessageBox.Show("Выберите должность для добавления сотрудника.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при открытии формы добавления сотрудника: {ex.Message}");
                MessageBox.Show($"Произошла ошибка при открытии формы добавления сотрудника: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task LoadEmployees(Position selectedPosition)
        {
            try
            {
                // Создаем новый экземпляр контекста для работы с базой данных
                using (var dbContext = new AppDbContext())
                {
                    // Получаем список сотрудников только для выбранной должности
                    List<Employee> employees = await employeeRepository.GetEmployeesByPositionIdUpdateLoad(dbContext, selectedPosition.PositionId);

                    // Преобразуем сотрудников в DTO перед отображением
                    List<EmployeeDTO> employeeDTOs = employees.Select(emp => EmployeeMapper.MapToDTO(emp)).ToList();

                    // Очищаем существующие строки в таблице
                    dataGridView1.Rows.Clear();

                    // Проверяем, что у dataGridView1 нет столбцов (например, при первоначальной инициализации)
                    if (dataGridView1.Columns.Count == 0)
                    {
                        // Создаем столбцы для фамилии, имени, отчества и даты приема на работу
                        DataGridViewColumn employeeIdColumn = new DataGridViewTextBoxColumn();
                        employeeIdColumn.Name = "EmployeeIdColumn";
                        employeeIdColumn.HeaderText = "Идентификатор сотрудника";
                        employeeIdColumn.Visible = false; // Делаем столбец невидимым
                        dataGridView1.Columns.Add(employeeIdColumn);

                        dataGridView1.Columns.Add("LastNameColumn", "Фамилия");
                        dataGridView1.Columns.Add("FirstNameColumn", "Имя");
                        dataGridView1.Columns.Add("MiddleNameColumn", "Отчество");
                        dataGridView1.Columns.Add("HireDateColumn", "Дата приема на работу");
                        dataGridView1.Columns.Add("PositionNameColumn", "Должность"); // Добавляем столбец для названия должности
                    }

                    // Добавляем строки для каждого сотрудника
                    foreach (var employeeDTO in employeeDTOs)
                    {
                        string positionTitle = await employeeRepository.GetPositionTitleByIdUpdateLoad(dbContext, employeeDTO.PositionId);
                        dataGridView1.Rows.Add(employeeDTO.EmployeeId, employeeDTO.LastName, employeeDTO.FirstName, employeeDTO.MiddleName, employeeDTO.HireDate, positionTitle);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при загрузке данных о работниках: {ex.Message}");
                MessageBox.Show($"Ошибка при загрузке данных о работниках: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private async void search_Click(object sender, EventArgs e)
        {
            try
            {
                string lastName = textBox1.Text.Trim();
                string firstName = textBox2.Text.Trim();
                string middleName = textBox3.Text.Trim();

                if (_selectedPosition != null)
                {
                    int positionId = _selectedPosition.PositionId;
                    List<Employee> foundEmployees = await SearchEmployees(positionId, lastName, firstName, middleName);

                    // Очищаем dataGridView1 перед добавлением результатов поиска
                    dataGridView1.Rows.Clear();

                    // Отображение найденных сотрудников в DataGridView
                    foreach (var employee in foundEmployees)
                    {
                        string positionTitle = await employeeRepository.GetPositionTitleById(employee.PositionId);
                        dataGridView1.Rows.Add(employee.EmployeeId, employee.LastName, employee.FirstName, employee.MiddleName, employee.HireDate, positionTitle);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите должность для выполнения поиска.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при выполнении поиска сотрудников: {ex.Message}");
                MessageBox.Show($"Произошла ошибка при выполнении поиска сотрудников: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private async Task<List<Employee>> SearchEmployees(int positionId, string lastName, string firstName, string middleName)
        {
            using (var dbContext = new AppDbContext())
            {
                IQueryable<Employee> query = dbContext.Employees.Where(e => e.PositionId == positionId);

                // Применение фильтров по фамилии, имени и отчеству
                if (!string.IsNullOrEmpty(lastName))
                {
                    query = query.Where(e => e.LastName.Contains(lastName));
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    query = query.Where(e => e.FirstName.Contains(firstName));
                }
                if (!string.IsNullOrEmpty(middleName))
                {
                    query = query.Where(e => e.MiddleName.Contains(middleName));
                }

                // Выполнение запроса и возврат списка найденных сотрудников
                return await query.ToListAsync();
            }
        }


        private void UpdateForm_DataUpdated(object sender, EventArgs e)
        {
            Logger.LogInformation("Обновление данных на форме");
            LoadEmployees(_selectedPosition);
        }


        private void delButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что хотя бы одна строка выбрана в DataGridView
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Получаем данные выбранной строки
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Получаем значение идентификатора сотрудника из ячейки с соответствующим именем столбца
                    if (selectedRow.Cells["EmployeeIdColumn"].Value != null && int.TryParse(selectedRow.Cells["EmployeeIdColumn"].Value.ToString(), out int employeeId))
                    {
                        // Создаем новый контекст для работы с базой данных
                        using (var dbContext = new AppDbContext())
                        {
                            // Находим сотрудника в базе данных по идентификатору
                            Employee employeeToDelete = dbContext.Employees.FirstOrDefault(emp => emp.EmployeeId == employeeId);
                            if (employeeToDelete != null)
                            {
                                // Удаляем сотрудника из базы данных
                                dbContext.Employees.Remove(employeeToDelete);
                                dbContext.SaveChanges();

                                // Удаляем строку из DataGridView
                                dataGridView1.Rows.Remove(selectedRow);
                            }
                            else
                            {
                                MessageBox.Show("Сотрудник не найден в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выбранная строка не содержит идентификатора сотрудника.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите строку в таблице для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при удалении сотрудника: {ex.Message}");
                MessageBox.Show($"Произошла ошибка при удалении сотрудника: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class AddEmployees : Form
    {
        private readonly int _positionId;
        private readonly IEmployeeRepository _employeeRepository;
        private static readonly ILogger Logger = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .AddFile("../Logs/mylog-{Date}.txt"); //bin/Debig/logs

            
        }).CreateLogger<AddEmployees>();

        public AddEmployees(int positionId, IEmployeeRepository employeeRepository)
        {
            InitializeComponent();
            _positionId = positionId; // Сохраняем переданный идентификатор должности
            _employeeRepository = employeeRepository; // Сохраняем переданный репозиторий

        }

        private async void ok_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные о работнике из полей формы
                string lastName = textBox1.Text;
                string firstName = textBox2.Text;
                string middleName = textBox3.Text;
                DateTime hireDate = dateTimePicker1.Value;

                // Создаем новый экземпляр Employee
                Employee newEmployee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    HireDate = hireDate,
                    PositionId = _positionId // Используем сохраненный идентификатор должности
                };

                // Добавляем нового работника, вызывая метод из репозитория
                await _employeeRepository.AddEmployee(newEmployee);

                // Получаем ссылку на родительскую форму EmployeesForm
                EmployeesForm employeesForm = (EmployeesForm)this.Owner;
                // Загружаем данные о работниках снова, чтобы отобразить добавленного работника
                employeesForm.LoadEmployees(employeesForm.SelectedPosition);

                // Закрываем текущее окно
                this.Close();
            }
            catch (DbUpdateException ex)
            {
                
                MessageBox.Show($"Ошибка сохранения данных: {ex.InnerException?.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Ошибка сохранения данных: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Произошла ошибка: {ex.Message}");
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void AddEmployees_Load(object sender, EventArgs e)
        {
            
        }

       
    }
}

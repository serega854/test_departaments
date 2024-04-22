using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace WinFormsApp5
{
    public partial class updateEmployees : Form
    {
        // Добавляем поля для хранения данных сотрудника
        private string _lastName;
        private string _firstName;
        private string _middleName;
        private DateTime _hireDate;

        public event EventHandler DataUpdated;

        // Логгер
        private static readonly ILogger Logger = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .AddFile("../Logs/mylog-{Date}.txt"); //bin/Debug/logs

        }).CreateLogger<updateEmployees>();

        public updateEmployees(string lastName, string firstName, string middleName, DateTime hireDate)
        {
            InitializeComponent();

            // Инициализируем поля данными сотрудника
            _lastName = lastName;
            _firstName = firstName;
            _middleName = middleName;
            _hireDate = hireDate;

            // Заполняем текстовые поля на форме данными сотрудника
            textBox1.Text = _lastName;
            textBox2.Text = _firstName;
            textBox3.Text = _middleName;
            dateTimePicker1.Value = _hireDate;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем новые значения из текстовых полей и элемента DateTimePicker
                string newLastName = textBox1.Text;
                string newFirstName = textBox2.Text;
                string newMiddleName = textBox3.Text;
                DateTime newHireDate = dateTimePicker1.Value;

                // Создаем новый контекст для работы с базой данных
                using (var dbContext = new AppDbContext())
                {
                    // Находим сотрудника в базе данных по старым данным
                    Employee employeeToUpdate = dbContext.Employees.FirstOrDefault(emp => emp.LastName == _lastName &&
                                                                                           emp.FirstName == _firstName &&
                                                                                           emp.MiddleName == _middleName &&
                                                                                           emp.HireDate == _hireDate);
                    if (employeeToUpdate != null)
                    {
                        // Обновляем данные сотрудника
                        employeeToUpdate.LastName = newLastName;
                        employeeToUpdate.FirstName = newFirstName;
                        employeeToUpdate.MiddleName = newMiddleName;
                        employeeToUpdate.HireDate = newHireDate;

                        // Сохраняем изменения в базе данных
                        dbContext.SaveChanges();

                        // Вызываем событие, указывая, что данные были обновлены
                        DataUpdated?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Сотрудник не найден в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                // Логируем ошибку
                Logger.LogError($"Ошибка при обновлении данных сотрудника: {ex.Message}");
                MessageBox.Show($"Произошла ошибка при обновлении данных сотрудника: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateEmployees_Load(object sender, EventArgs e)
        {
        }
    }
}

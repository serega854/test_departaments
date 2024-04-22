using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace WinFormsApp5
{
    public partial class AddBranch : Form
    {
        private int parentDepartmentId; 
        private DepartmentForm departmentForm; 
        private static readonly ILogger Logger = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole(options => options.IncludeScopes = true)
                .AddFile("../Logs/mylog-{Date}.txt"); //bin/Debig/logs

            
        }).CreateLogger<AddBranch>();

        public AddBranch(int parentDepartmentId, DepartmentForm departmentForm)
        {
            InitializeComponent();
            this.parentDepartmentId = parentDepartmentId;
            this.departmentForm = departmentForm; // Сохраняем ссылку на главную форму
        }

        private async void ok_Click(object sender, EventArgs e)
        {
            string childName = textBox1.Text; // Получаем наименование новой ветки

            // В зависимости от выбранного типа ветки добавляем новое подразделение или должность
            if (comboBox1.SelectedItem != null)
            {
                string selectedType = comboBox1.SelectedItem.ToString();
                Logger.LogInformation("Выбранный тип: " + selectedType);

                if (selectedType == "Подразделение")
                {
                    Logger.LogInformation("Добавление нового подразделения...");
                    Department newDepartment = new Department
                    {
                        Name = childName,
                        ParentDepartmentId = parentDepartmentId // Сохраняем айди родительского подразделения
                    };

                    try
                    {
                        // Добавляем новое подразделение в базу данных
                        using (var departmentRepository = new DepartmentRepository(new AppDbContext()))
                        {
                            await departmentRepository.AddDepartmentAsync(newDepartment);
                        }

                        Logger.LogInformation("Новое подразделение успешно добавлено!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при добавлении подразделения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.LogError("Ошибка при добавлении нового подразделения: " + ex.Message);
                    }
                }
                else if (selectedType == "Должность")
                {
                    Logger.LogInformation("Добавление новой должности...");
                    Position newPosition = new Position
                    {
                        Title = childName,
                        DepartmentId = parentDepartmentId // Сохраняем айди родительского подразделения
                    };

                    try
                    {
                        // Добавляем новую должность в базу данных
                        using (var positionRepository = new PositionRepository(new AppDbContext()))
                        {
                            await positionRepository.AddPositionAsync(newPosition);
                        }

                        Logger.LogInformation("Новая должность успешно добавлена!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при добавлении должности: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.LogError("Ошибка при добавлении новой должности: " + ex.Message);
                    }
                }

                this.Close(); // Закрываем форму после добавления ветки

                // Вызываем метод обновления данных в главной форме
                departmentForm.select_click(sender, e);
            }
            else
            {
                MessageBox.Show("Выберите тип ветки (Подразделение или Должность).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogWarning("Не выбран тип!");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрываем форму при отмене
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

       
        private void UpdateBranch_Load(object sender, EventArgs e)
        {
            
        }
    }
}

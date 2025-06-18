using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using System.Diagnostics;
using MySql.Data.MySqlClient;
namespace Notes
{
    public partial class Form1 : Form
    {
        string connectionString = "server=localhost;user=root;password=2231;database=NotesApp;";
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadNotes()
        {
            listBoxNotes.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, title FROM Notes ORDER BY created_at DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        listBoxNotes.Items.Add("Здесь будут отображаться ваши заметки");
                        listBoxNotes.Enabled = false;
                    }
                    else
                    {
                        listBoxNotes.Enabled = true;
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string title = reader.GetString("title");
                            listBoxNotes.Items.Add($"{id}: {title}");
                        }
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnDelete.FlatAppearance.BorderSize = 1;
            btnDelete.BackColor = Color.White;

            btnDelete.MouseEnter += (s, e) =>
            {
                btnDelete.BackColor = Color.FromArgb(255, 200, 200);
            };

            btnDelete.MouseLeave += (s, e) =>
            {
                btnDelete.BackColor = Color.White;
            };
            LoadNotes();
            SetPlaceholder(textBoxTitle, "Введите заголовок заметки"); // создаем плейсхолдер
            SetPlaceholder(richTextBoxNote, "Введите содержимое заметки");
        }
        private void ClearNoteFields()
        {
            textBoxTitle.Enter -= TextBoxEnterHandler;
            textBoxTitle.Leave -= TextBoxLeaveHandler;
            richTextBoxNote.Enter -= TextBoxEnterHandler;
            richTextBoxNote.Leave -= TextBoxLeaveHandler;
            SetPlaceholder(textBoxTitle, "Введите заголовок заметки");
            SetPlaceholder(richTextBoxNote, "Введите содержимое заметки");
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.ActiveControl = null;
        }
        private void SetPlaceholder(Control control, string placeholder)
        {
            control.Text = placeholder;
            control.ForeColor = Color.Gray;
            EventHandler enterHandler = null;
            EventHandler leaveHandler = null;

            enterHandler = (s, e) =>
            {
                if (control.Text == placeholder)
                {
                    control.Text = "";
                    control.ForeColor = Color.Black;
                }
            };
            leaveHandler = (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    control.Text = placeholder;
                    control.ForeColor = Color.Gray;
                }
            };
            control.Enter += enterHandler;
            control.Leave += leaveHandler;
            TextBoxEnterHandler = enterHandler;
            TextBoxLeaveHandler = leaveHandler;
        }
        private EventHandler TextBoxEnterHandler;
        private EventHandler TextBoxLeaveHandler;
        private void listBoxNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxNotes.SelectedItem == null) return;
            string selected = listBoxNotes.SelectedItem.ToString();
            int colonIndex = selected.IndexOf(':');
            if (colonIndex == -1) return;

            int id = int.Parse(selected.Substring(0, colonIndex));

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT title, content FROM Notes WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxTitle.Text = reader.GetString("title");
                            richTextBoxNote.Text = reader.GetString("content");
                        }
                    }
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e) // создаем скрипт, чтобы по нажатию на кнопку "добавить" заметка добавлялась в БД
        {
            ClearNoteFields();
            string title = textBoxTitle.Text.Trim();
            string content = richTextBoxNote.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Введите заголовок заметки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Notes (title, content, created_at) VALUES (@title, @content, NOW())";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@content", content);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Заметка добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxTitle.Clear();
            richTextBoxNote.Clear();
            LoadNotes();
        }
        private void btnUpdate_Click(object sender, EventArgs e) // редактирование заметок
        {
            if (listBoxNotes.SelectedItem == null)
            {
                MessageBox.Show("Выберите заметку для обновления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selected = listBoxNotes.SelectedItem.ToString();
            int colonIndex = selected.IndexOf(':');
            if (colonIndex == -1) return;

            int id = int.Parse(selected.Substring(0, colonIndex));
            string newTitle = textBoxTitle.Text.Trim();
            string newContent = richTextBoxNote.Text.Trim();

            if (string.IsNullOrWhiteSpace(newTitle))
            {
                MessageBox.Show("Заголовок не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Notes SET title = @title, content = @content WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", newTitle);
                    cmd.Parameters.AddWithValue("@content", newContent);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Заметка обновлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadNotes();
        }
        private void btnDelete_Click(object sender, EventArgs e) // удаление заметок
        {
            ClearNoteFields();
            if (listBoxNotes.SelectedItem == null)
            {
                MessageBox.Show("Выберите заметку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Вы действительно хотите удалить эту заметку?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            string selected = listBoxNotes.SelectedItem.ToString();
            int colonIndex = selected.IndexOf(':');
            if (colonIndex == -1) return;

            int id = int.Parse(selected.Substring(0, colonIndex));

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Notes WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Заметка удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxTitle.Clear();
            richTextBoxNote.Clear();
            LoadNotes();
        }
        private void btnSearch_Click(object sender, EventArgs e) // кнопка поиска
        {
            string searchText = textBoxSearch.Text.Trim();

            listBoxNotes.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, title FROM Notes WHERE title LIKE @search ORDER BY created_at DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string title = reader.GetString("title");
                            listBoxNotes.Items.Add($"{id}: {title}");
                        }
                    }
                }
            }
        }
        private void btnClearSelection_Click(object sender, EventArgs e) // отмена выбора заметки из левой панели
        {
            ClearNoteFields();
            listBoxNotes.ClearSelected();
            textBoxTitle.Clear();
            richTextBoxNote.Clear();
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text) && string.IsNullOrWhiteSpace(richTextBoxNote.Text))
            {
                MessageBox.Show("Нет данных для экспорта.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF файлы (*.pdf)|*.pdf";
                sfd.FileName = textBoxTitle.Text.Trim() + ".pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PdfDocument document = new PdfDocument();
                        document.Info.Title = textBoxTitle.Text;

                        PdfPage page = document.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        var font = new XFont("Arial", 14, XFontStyle.Bold);
                        gfx.DrawString(textBoxTitle.Text, font, XBrushes.Black, new XRect(40, 40, page.Width - 80, 40), XStringFormats.TopLeft);
                        gfx.DrawString(richTextBoxNote.Text, font, XBrushes.Black, new XRect(40, 80, page.Width - 80, page.Height - 120), XStringFormats.TopLeft);

                        document.Save(sfd.FileName);
                        Process.Start("explorer.exe", $"/select,\"{sfd.FileName}\"");

                        MessageBox.Show("PDF успешно сохранён.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении PDF: " + ex.Message);
                    }
                }
            }
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
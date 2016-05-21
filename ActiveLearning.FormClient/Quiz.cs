using ActiveLearning.FormClient.StudentService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveLearning.FormClient
{
    public partial class Quiz : Form
    {
        StudentServiceClient client;
        int courseSid;
        private QuizQuestionDTO quizQuestion;

        public Quiz(StudentServiceClient client, int courseSid)
        {
            this.client = client;
            this.courseSid = courseSid;
            InitializeComponent();

            ListBoxOptions.DisplayMember = "Title";
            ListBoxOptions.ValueMember = "Sid";
            ListBoxOptions.SelectionMode = SelectionMode.One;

        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            GetNextQuestion();
        }

        private async void GetNextQuestion()
        {
            ListBoxOptions.Items.Clear();
            LblQuestion.Text = string.Empty;
            try
            {
                quizQuestion = await client.GetNextQuizQuestionByCourseSidAsync(courseSid);
                LblQuestion.Text = quizQuestion.Title;

                foreach (var option in quizQuestion.QuizOptions)
                {
                    ListBoxOptions.Items.Add(option);
                }
            }
            catch (FaultException fe)
            {
                MessageBox.Show(fe.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private async Task SubmitAnswer()
        {
            int answer = (ListBoxOptions.SelectedItem as QuizOptionDTO).Sid;
            bool? isCorrect = null;
            try
            {
                isCorrect = await client.AnswerQuizAsync(quizQuestion.Sid, answer);
            }
            catch (FaultException fe)
            {
                MessageBox.Show(fe.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (isCorrect == true)
            {
                MessageBox.Show("Correct !");
            }
            else
            {
                MessageBox.Show("Wrong !");
            }

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            await SubmitAnswer();
            GetNextQuestion();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_pratico_3_final
{
    public partial class frm_Aluno : Form
    {
        int alunoaalterar = -1;
        struct Notas
        {
            int nota1;
            int nota2;
            int nota3;
            int nota4;
            int nota5;
            int medias;

            public Notas(int not1, int not2, int not3, int not4, int not5)
            {
                nota1 = not1;
                nota2 = not2;
                nota3 = not3;
                nota4 = not4;
                nota5 = not5;
                medias = 0;
                calculamedia();
            }

            public void calculamedia()
            {
                medias = (nota1 + nota2 + nota3 + nota4 + nota5) / 5;
            }

            public int Getmedia()
            {
                return medias;
            }

            public string Mostrar()
            {
                string dados = "";
                dados = "Nota1: " + nota1 + "\n Nota2: " + nota2 + "\n Nota3: " + nota3 + "\n Nota4: " + nota4 + "\n Nota5: " + nota5;
                return dados;
            }

            public int Mostrarnota1()
            {
                int Nota1 = 0;
                Nota1 = nota1;
                return Nota1;
            }

            public int Mostrarnota2()
            {
                int Nota2 = 0;
                Nota2 = nota2;
                return Nota2;
            }

            public int Mostrarnota3()
            {
                int Nota3 = 0;
                Nota3 = nota3;
                return Nota3;
            }

            public int Mostrarnota4()
            {
                int Nota4 = 0;
                Nota4 = nota4;
                return Nota4;
            }

            public int Mostrarnota5()
            {
                int Nota5 = 0;
                Nota5 = nota5;
                return Nota5;
            }

        }//fim notas
       
        struct Aluno
        {
            int numero;
            int anocurricular;
            string nome;
            int idade;
            DateTime datadenascimento;
            Notas notas;
            string normal;
            string sexo;


            public Aluno(int i, string n, int nu, int ano, Notas res, DateTime data, string trabalhador, string sex)
            {
                numero = nu;
                anocurricular = ano;
                nome = n;
                idade = i;
                datadenascimento = data;
                normal = trabalhador;
                notas = res;
                sexo = sex;
            }


            public void SetNumero(int nu)
            {
                numero = nu;
            }

            public int GetNumero()
            {
                return numero;
            }

            public void SetAnocurricolar(int ano)
            {
                anocurricular = ano;
            }

            public int GetAnocurricular()
            {
                return anocurricular;
            }

            public void SetNome(string n)
            {
                nome = n;
            }

            public string GetNome()
            {
                return nome;
            }

            public void SetIdade(int i)
            {
                idade = i;
            }

            public int GetIdade()
            {
                return idade;
            }

            public void SetDatadenascimento(DateTime data)
            {
                datadenascimento = data;
            }

            public DateTime GetDatadenascimento()
            {
                return datadenascimento;
            }

            public void SetTrabalho(string trabalhador)
            {
                normal = trabalhador;
            }

            public string GetTrabalho()
            {
                return normal;
            }

            public void SetNotas(Notas not)
            {
                notas = not;
            }

            public Notas GetNotas()
            {
                return notas;
            }

            public void SetSexo(string sex)
            {
                sexo = sex;
            }

            public string GetSexo()
            {
                return sexo;
            }

            public string Mostrar()
            {
                
                string dados = "";
                dados = dados + " Nome: " + nome;
                dados = dados + "\n idade: " + idade;
                dados = dados + "\n sexo : " + sexo;
                dados = dados + "\n numero: " + numero;
                dados = dados + "\n do ano : " + anocurricular;
                dados = dados + "\n Nasceu em: " + datadenascimento.ToShortDateString();
                dados = dados + "\n" + normal;
                dados = dados + "\n" + notas.Mostrar();
                return dados;
            }


        }//Fim aluno

        Aluno[] VA = new Aluno[1015];
        int contador = 0;

        public frm_Aluno()
        {
            InitializeComponent();
        }

        private void bt_sair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a aplicação ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bt_adicionarpessoa_Click(object sender, EventArgs e)
        {
           
            //validações 
            int inteiro = 0;
            bool valido = true;
            string motivo = "";
            bool Existenumero = false;

            if (txt_Nome.Text == "") 
            {
                valido = false; 
                motivo = "Nome incompleto \n";
            }//valida se o nome está em branco

            if (txt_numero.Text == "" || int.TryParse(txt_numero.Text, out inteiro) == false) 
            { 
                valido = false; 
                motivo = motivo +  "Número errado \n"; 
            }

            for (int i = 0; i < contador; i++)
            {
                if (VA[i].GetNumero() == Convert.ToInt32(txt_numero.Text))
                {
                    Existenumero = true;
                }
            }
            if (Existenumero == true) 
            {
                valido = false; 
                motivo = motivo + "Número repetido \n"; 
            }
 
            if (txt_anocurricular.Text == "" || int.TryParse(txt_anocurricular.Text, out inteiro) == false) 
            {
                valido = false;
                motivo = motivo + "Ano curricular errado \n";
            }

            if (rb_estudante.Checked == false && rb_trabalhadorestudante.Checked == false) 
            {
                valido = false; 
                motivo = motivo + "Não selecionou o estatuto do aluno \n";
            }
           
            if(Convert.ToDateTime(dtp_datadenascimento.Value).Date == DateTime.Now.Date )
            {
                valido = false;
                motivo = motivo + "Não selecionou a nascimento do aluno \n";
            }

            if(rb_mulher.Checked == false && rb_homem.Checked == false)
            {
                valido = false;
                motivo = motivo + "Não selecionou o sexo do aluno \n";
            }



            if (txt_notas1.Text == "" || int.TryParse(txt_notas1.Text, out inteiro) == false)
            {
                valido = false;
                motivo = motivo + "Não introduziu a Nota 1 do aluno \n";
            }
            else
            {
                int.TryParse(txt_notas1.Text, out inteiro);
                int.TryParse(txt_notas1.Text, out inteiro);
                if (inteiro < 0 || inteiro > 20)
                {
                    valido = false;
                    motivo = motivo + "Introduziu um valor errado na Nota 1 na escala de 0 a 20 \n";
                }
            }

            if (txt_notas2.Text == "" || int.TryParse(txt_notas2.Text, out inteiro) == false)
            {
                valido = false;
                motivo = motivo + "Não introduziu a Nota 2 do aluno \n";
            }
            else
            {
                int.TryParse(txt_notas2.Text, out inteiro);
                int.TryParse(txt_notas2.Text, out inteiro);
                if (inteiro < 0 || inteiro > 20)
                {
                    valido = false;
                    motivo = motivo + "Introduziu um valor errado na Nota 1 na escala de 0 a 20 \n";
                }
            }

            if (txt_notas3.Text == "" || int.TryParse(txt_notas3.Text, out inteiro) == false)
            {
                valido = false;
                motivo = motivo + "Não introduziu a Nota 3 do aluno \n";
            }
            else
            {
                int.TryParse(txt_notas3.Text, out inteiro);
                int.TryParse(txt_notas3.Text, out inteiro);
                if (inteiro < 0 || inteiro > 20)
                {
                    valido = false;
                    motivo = motivo + "Introduziu um valor errado na Nota 1 na escala de 0 a 20 \n";
                }
            }

            if (txt_notas4.Text == "" || int.TryParse(txt_notas4.Text, out inteiro) == false)
            {
                valido = false;
                motivo = motivo + "Não introduziu a Nota 4 do aluno \n";
            }
            else
            {
                int.TryParse(txt_notas4.Text, out inteiro);
                int.TryParse(txt_notas4.Text, out inteiro);
                if (inteiro < 0 || inteiro > 20)
                {
                    valido = false;
                    motivo = motivo + "Introduziu um valor errado na Nota 1 na escala de 0 a 20 \n";
                }
            }

            if (txt_notas5.Text == "" || int.TryParse(txt_notas5.Text, out inteiro) == false)
            {
                valido = false;
                motivo = motivo + "Não introduziu a Nota 5 do aluno \n";
            }
            else    
            {
                int.TryParse(txt_notas5.Text, out inteiro);
                int.TryParse(txt_notas5.Text, out inteiro);
                if (inteiro < 0 || inteiro > 20)
                {
                    valido = false;
                    motivo = motivo + "Introduziu um valor errado na Nota 1 na escala de 0 a 20 \n";
                }                
            }

            //if (int.TryParse(txt_notas1.Text < -1) || int.TryParse(txt_notas1.Text > 20))
            //{
            //    valido = false;
            //    motivo = motivo + "Não introduziu a Nota 1 do aluno \n";
            //}

            // continuas a validar  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


            if (valido == false)
            {
                // encontrou pelo menos 1 erro
                MessageBox.Show(motivo);
            }
            else 
            { 
            
                VA[contador].SetNome(txt_Nome.Text);
                VA[contador].SetIdade(Convert.ToInt32(txt_idade.Text));
                VA[contador].SetDatadenascimento(Convert.ToDateTime(dtp_datadenascimento.Value));
                VA[contador].SetNumero(Int32.Parse(txt_numero.Text));
                VA[contador].SetAnocurricolar(Int32.Parse(txt_anocurricular.Text));
                if (rb_estudante.Checked)
                {
                    VA[contador].SetTrabalho(" Estudante ");
                }
                else
                {
                    VA[contador].SetTrabalho(" Trabalhador Estudante ");
                }//fim TRABALHADOR ESTUDANTE

                if (rb_homem.Checked)
                {
                    VA[contador].SetSexo("Homem");
                }
                else
                {
                    VA[contador].SetSexo("Mulher");
                }//FIM SEXO

                Notas Notas = new Notas(Convert.ToInt32(txt_notas1.Text), Convert.ToInt32(txt_notas2.Text), Convert.ToInt32(txt_notas3.Text), Convert.ToInt32(txt_notas4.Text), Convert.ToInt32(txt_notas5.Text));
                VA[contador].SetNotas(Notas);
                //fim notas

                contador++;
                MessageBox.Show("Aluno Intoduzido com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparinfoaluno();

                if (contador == 1015)
                {
                    btn_adicionarpessoa.Visible = false;
                    MessageBox.Show("Chegou ao limite de alunos inseridos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void bt_Mostrar_Click(object sender, EventArgs e)
        {
            mostrar_conteudo();
        }//Fim Mostrar

        private void bt_contar_Click(object sender, EventArgs e)
        {
            int Contadorcontar = 0;

            if (rb_contaralunos.Checked)
            {
                lb_contar.Items.Clear();

                for (int i = 0; i < contador; i++)
                {
                    if (VA[i].GetAnocurricular() == Convert.ToInt32(txt_contarano.Text))
                    {
                        Contadorcontar++;
                    }
                }

                lb_contar.Items.Add(Contadorcontar);

            }//Contar anos

            if (rb_contarmedianegativa.Checked)
            {
                lb_contar.Items.Clear();

                for (int i = 0; i < contador; i++)
                {
                   if (VA[i].GetNotas().Getmedia() >0 && VA[i].GetNotas().Getmedia()<10)
                    {
                        Contadorcontar++;
                    }
                    
                }

                lb_contar.Items.Add(Contadorcontar);
            }//Contar Média Negativa

            if (rb_contarmediapositiva.Checked)
            {
                lb_contar.Items.Clear();

                for (int i = 0; i < contador; i++)
                {
                    if (VA[i].GetNotas().Getmedia() >= 10 && VA[i].GetNotas().Getmedia() <= 20)
                    {
                        Contadorcontar++;
                    }

                }

                lb_contar.Items.Add(Contadorcontar);
            }//Contar Média Positiva

            if (rb_totaldealunos.Checked)
            {
                lb_contar.Items.Clear();
                lb_contar.Items.Add(contador);
            }

        }//fim contar
        

        private void dtp_datadenascimento_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan diff = DateTime.Today - dtp_datadenascimento.Value;
            txt_idade.Text = Convert.ToString(diff.Days / 366); 
        }

        private void frm_Aluno_Load(object sender, EventArgs e)
        {
            dtp_datadenascimento.Value = DateTime.Now;
            gp_list.Enabled = false;
            btn_atualizar_dados.Visible = false;
            btn_cancelar.Visible = false;
            btn_adicionarpessoa.Visible = true;
            btn_limpar.Visible = true;

            pic_list.Enabled = true;
            pic_list.Image = Trabalho_pratico_3_final.Properties.Resources.list;
            pic_aluno.Enabled = false;
            pic_aluno.Image = Trabalho_pratico_3_final.Properties.Resources.person_dis;

        }

        private void pic_pic_Click(object sender, EventArgs e)
        {
            pic_aluno.Image = Trabalho_pratico_3_final.Properties.Resources.person_dis;
            pic_aluno.Enabled = false;
            pic_list.Image = Trabalho_pratico_3_final.Properties.Resources.list;
            pic_list.Enabled = true;

            limparinfoaluno();
            gp_list.Enabled = false;
            gp_aluno.Enabled = true;
           
        }

        private void limparinfoaluno()
        {
            txt_anocurricular.Text = "";
            txt_Nome.Text = "";
            txt_notas1.Text = "";
            txt_notas2.Text = "";
            txt_notas3.Text = "";
            txt_notas4.Text = "";
            txt_notas5.Text = "";
            txt_numero.Text = "";
            txt_idade.Text = "";
            rb_estudante.Checked = false;
            rb_trabalhadorestudante.Checked = false;
            rb_mulher.Checked = false;
            rb_homem.Checked = false;
            dtp_datadenascimento.ResetText();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparinfoaluno();
        }


        private void dgv_mostrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int columnIndex = dgv_mostrar.CurrentCell.ColumnIndex;//coluna seleccionada

                    if (dgv_mostrar.SelectedCells.Count > 0 && columnIndex == 13)
                    {
                        if (MessageBox.Show("", "Deseja eliminar?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            int selectedrowindex = dgv_mostrar.SelectedCells[0].RowIndex;
                            int index =  Convert.ToInt32(dgv_mostrar.Rows[selectedrowindex].Cells[0].Value.ToString());
                
                            for (int i = index; i < contador - 1; i++)
                            {
                                VA[i] = VA[i + 1];
                            }
                            contador--;
                            mostrar_conteudo(); 
                        }
                    }
           
        }

        public void mostrar_conteudo() 
        {
            dgv_mostrar.Rows.Clear();
            if (rb_mostrartodos.Checked)
            {
                for (int i = 0; i < contador; i++)
                {
                    int line = dgv_mostrar.Rows.Add();
                    dgv_mostrar.Rows[line].Cells[0].Value = i;
                    dgv_mostrar.Rows[line].Cells[1].Value = VA[i].GetNome();
                    dgv_mostrar.Rows[line].Cells[2].Value = VA[i].GetNumero();
                    dgv_mostrar.Rows[line].Cells[3].Value = VA[i].GetIdade();
                    dgv_mostrar.Rows[line].Cells[4].Value = VA[i].GetSexo();
                    dgv_mostrar.Rows[line].Cells[5].Value = VA[i].GetDatadenascimento().ToShortDateString();
                    dgv_mostrar.Rows[line].Cells[6].Value = VA[i].GetTrabalho();
                    dgv_mostrar.Rows[line].Cells[7].Value = VA[i].GetAnocurricular();
                    dgv_mostrar.Rows[line].Cells[8].Value = VA[i].GetNotas().Mostrarnota1();
                    dgv_mostrar.Rows[line].Cells[9].Value = VA[i].GetNotas().Mostrarnota2();
                    dgv_mostrar.Rows[line].Cells[10].Value = VA[i].GetNotas().Mostrarnota3();
                    dgv_mostrar.Rows[line].Cells[11].Value = VA[i].GetNotas().Mostrarnota4();
                    dgv_mostrar.Rows[line].Cells[12].Value = VA[i].GetNotas().Mostrarnota5();
                }
            }

            if (rb_umAluno.Checked)
            {
                for (int i = 0; i < contador; i++)
                {
                    if (VA[i].GetNumero() == Convert.ToInt32(txt_escolhernumero.Text))
                    {
                        int line = dgv_mostrar.Rows.Add();
                        dgv_mostrar.Rows[line].Cells[0].Value = i;
                        dgv_mostrar.Rows[line].Cells[1].Value = VA[i].GetNome();
                        dgv_mostrar.Rows[line].Cells[2].Value = VA[i].GetNumero();
                        dgv_mostrar.Rows[line].Cells[3].Value = VA[i].GetIdade();
                        dgv_mostrar.Rows[line].Cells[4].Value = VA[i].GetSexo();
                        dgv_mostrar.Rows[line].Cells[5].Value = VA[i].GetDatadenascimento().ToShortDateString();
                        dgv_mostrar.Rows[line].Cells[6].Value = VA[i].GetTrabalho();
                        dgv_mostrar.Rows[line].Cells[7].Value = VA[i].GetAnocurricular();
                        dgv_mostrar.Rows[line].Cells[8].Value = VA[i].GetNotas().Mostrarnota1();
                        dgv_mostrar.Rows[line].Cells[9].Value = VA[i].GetNotas().Mostrarnota2();
                        dgv_mostrar.Rows[line].Cells[10].Value = VA[i].GetNotas().Mostrarnota3();
                        dgv_mostrar.Rows[line].Cells[11].Value = VA[i].GetNotas().Mostrarnota4();
                        dgv_mostrar.Rows[line].Cells[12].Value = VA[i].GetNotas().Mostrarnota5();
                    }
                }
            }//Mostrar a partir do numero
            else if (rb_mostrarano.Checked)
            {
                for (int i = 0; i < contador; i++)
                {
                    if (VA[i].GetAnocurricular() == Convert.ToInt32(txt_mostrarano.Text))
                    {
                        int line = dgv_mostrar.Rows.Add();
                        dgv_mostrar.Rows[line].Cells[0].Value = i;
                        dgv_mostrar.Rows[line].Cells[1].Value = VA[i].GetNome();
                        dgv_mostrar.Rows[line].Cells[2].Value = VA[i].GetNumero();
                        dgv_mostrar.Rows[line].Cells[3].Value = VA[i].GetIdade();
                        dgv_mostrar.Rows[line].Cells[4].Value = VA[i].GetSexo();
                        dgv_mostrar.Rows[line].Cells[5].Value = VA[i].GetDatadenascimento().ToShortDateString();
                        dgv_mostrar.Rows[line].Cells[6].Value = VA[i].GetTrabalho();
                        dgv_mostrar.Rows[line].Cells[7].Value = VA[i].GetAnocurricular();
                        dgv_mostrar.Rows[line].Cells[8].Value = VA[i].GetNotas().Mostrarnota1();
                        dgv_mostrar.Rows[line].Cells[9].Value = VA[i].GetNotas().Mostrarnota2();
                        dgv_mostrar.Rows[line].Cells[10].Value = VA[i].GetNotas().Mostrarnota3();
                        dgv_mostrar.Rows[line].Cells[11].Value = VA[i].GetNotas().Mostrarnota4();
                        dgv_mostrar.Rows[line].Cells[12].Value = VA[i].GetNotas().Mostrarnota5();
                    }
                }
            }//Mostrar a partir do ano
            else if (rb_mostrarestudante.Checked)
            {
                for (int i = 0; i < contador; i++)
                {
                    if (VA[i].GetTrabalho() == " Estudante ")
                    {
                        int line = dgv_mostrar.Rows.Add();
                        dgv_mostrar.Rows[line].Cells[0].Value = i;
                        dgv_mostrar.Rows[line].Cells[1].Value = VA[i].GetNome();
                        dgv_mostrar.Rows[line].Cells[2].Value = VA[i].GetNumero();
                        dgv_mostrar.Rows[line].Cells[3].Value = VA[i].GetIdade();
                        dgv_mostrar.Rows[line].Cells[4].Value = VA[i].GetSexo();
                        dgv_mostrar.Rows[line].Cells[5].Value = VA[i].GetDatadenascimento().ToShortDateString();
                        dgv_mostrar.Rows[line].Cells[6].Value = VA[i].GetTrabalho();
                        dgv_mostrar.Rows[line].Cells[7].Value = VA[i].GetAnocurricular();
                        dgv_mostrar.Rows[line].Cells[8].Value = VA[i].GetNotas().Mostrarnota1();
                        dgv_mostrar.Rows[line].Cells[9].Value = VA[i].GetNotas().Mostrarnota2();
                        dgv_mostrar.Rows[line].Cells[10].Value = VA[i].GetNotas().Mostrarnota3();
                        dgv_mostrar.Rows[line].Cells[11].Value = VA[i].GetNotas().Mostrarnota4();
                        dgv_mostrar.Rows[line].Cells[12].Value = VA[i].GetNotas().Mostrarnota5();
                    }
                }
            }//mostrar estudantes

            else if (rb_mostrartrabalhador.Checked)
            {
                for (int i = 0; i < contador; i++)
                {
                    if (VA[i].GetTrabalho() == " Trabalhador Estudante ")
                    {
                        int line = dgv_mostrar.Rows.Add();
                        dgv_mostrar.Rows[line].Cells[0].Value = i;
                        dgv_mostrar.Rows[line].Cells[1].Value = VA[i].GetNome();
                        dgv_mostrar.Rows[line].Cells[2].Value = VA[i].GetNumero();
                        dgv_mostrar.Rows[line].Cells[3].Value = VA[i].GetIdade();
                        dgv_mostrar.Rows[line].Cells[4].Value = VA[i].GetSexo();
                        dgv_mostrar.Rows[line].Cells[5].Value = VA[i].GetDatadenascimento().ToShortDateString();
                        dgv_mostrar.Rows[line].Cells[6].Value = VA[i].GetTrabalho();
                        dgv_mostrar.Rows[line].Cells[7].Value = VA[i].GetAnocurricular();
                        dgv_mostrar.Rows[line].Cells[8].Value = VA[i].GetNotas().Mostrarnota1();
                        dgv_mostrar.Rows[line].Cells[9].Value = VA[i].GetNotas().Mostrarnota2();
                        dgv_mostrar.Rows[line].Cells[10].Value = VA[i].GetNotas().Mostrarnota3();
                        dgv_mostrar.Rows[line].Cells[11].Value = VA[i].GetNotas().Mostrarnota4();
                        dgv_mostrar.Rows[line].Cells[12].Value = VA[i].GetNotas().Mostrarnota5();
                    }
                }
            }//Mostrar alunos trabalhadores

            else if (rb_mostrarmaisvelho.Checked)
            {
                int idades = VA[0].GetIdade();
                for (int i = 0; i < contador; i++)
                {
                    if (VA[i].GetIdade() > idades)
                    {
                        idades = VA[i].GetIdade();
                    }
                }
                //Ciclo para procurar a idade armazenada em "idades"
                for (int i = 0; i < contador; i++)
                {
                    if (VA[i].GetIdade() == idades)
                    {
                        int line = dgv_mostrar.Rows.Add();
                        dgv_mostrar.Rows[line].Cells[0].Value = i;
                        dgv_mostrar.Rows[line].Cells[1].Value = VA[i].GetNome();
                        dgv_mostrar.Rows[line].Cells[2].Value = VA[i].GetNumero();
                        dgv_mostrar.Rows[line].Cells[3].Value = VA[i].GetIdade();
                        dgv_mostrar.Rows[line].Cells[4].Value = VA[i].GetSexo();
                        dgv_mostrar.Rows[line].Cells[5].Value = VA[i].GetDatadenascimento().ToShortDateString();
                        dgv_mostrar.Rows[line].Cells[6].Value = VA[i].GetTrabalho();
                        dgv_mostrar.Rows[line].Cells[7].Value = VA[i].GetAnocurricular();
                        dgv_mostrar.Rows[line].Cells[8].Value = VA[i].GetNotas().Mostrarnota1();
                        dgv_mostrar.Rows[line].Cells[9].Value = VA[i].GetNotas().Mostrarnota2();
                        dgv_mostrar.Rows[line].Cells[10].Value = VA[i].GetNotas().Mostrarnota3();
                        dgv_mostrar.Rows[line].Cells[11].Value = VA[i].GetNotas().Mostrarnota4();
                        dgv_mostrar.Rows[line].Cells[12].Value = VA[i].GetNotas().Mostrarnota5();
                    }
                }
            }//Mostrar aluno mais velho

            else if (rb_mostraraniversariante.Checked)
            {
                for (int i = 0; i < contador; i++)
                {
                    if (VA[i].GetDatadenascimento().Day == DateTime.Today.Day && VA[i].GetDatadenascimento().Month == DateTime.Today.Month)
                    {

                        int line = dgv_mostrar.Rows.Add();
                        dgv_mostrar.Rows[line].Cells[0].Value = i;
                        dgv_mostrar.Rows[line].Cells[1].Value = VA[i].GetNome();
                        dgv_mostrar.Rows[line].Cells[2].Value = VA[i].GetNumero();
                        dgv_mostrar.Rows[line].Cells[3].Value = VA[i].GetIdade();
                        dgv_mostrar.Rows[line].Cells[4].Value = VA[i].GetSexo();
                        dgv_mostrar.Rows[line].Cells[5].Value = VA[i].GetDatadenascimento().ToShortDateString();
                        dgv_mostrar.Rows[line].Cells[6].Value = VA[i].GetTrabalho();
                        dgv_mostrar.Rows[line].Cells[7].Value = VA[i].GetAnocurricular();
                        dgv_mostrar.Rows[line].Cells[8].Value = VA[i].GetNotas().Mostrarnota1();
                        dgv_mostrar.Rows[line].Cells[9].Value = VA[i].GetNotas().Mostrarnota2();
                        dgv_mostrar.Rows[line].Cells[10].Value = VA[i].GetNotas().Mostrarnota3();
                        dgv_mostrar.Rows[line].Cells[11].Value = VA[i].GetNotas().Mostrarnota4();
                        dgv_mostrar.Rows[line].Cells[12].Value = VA[i].GetNotas().Mostrarnota5();
                    }
                }
            }//Mostrar aniversariante

            else if (rb_mostrarmelhormedia.Checked)
            {
                var maiorMedia = VA[0].GetNotas().Getmedia();
                for (int i = 0; i < contador; i++)
                {
                    if (VA[i].GetNotas().Getmedia() > maiorMedia)
                    {
                        maiorMedia = VA[i].GetNotas().Getmedia();
                    }
                }

                //Corre o array dos alunos e mostra o que tem a maiorMedia
                foreach (Aluno aluno in VA)
                {
                    if (aluno.GetNotas().Getmedia() == maiorMedia)
                    {
                        for (int i = 0; i < contador; i++)
                        {
                            int line = dgv_mostrar.Rows.Add();
                            dgv_mostrar.Rows[line].Cells[0].Value = i;
                            dgv_mostrar.Rows[line].Cells[1].Value = VA[i].GetNome();
                            dgv_mostrar.Rows[line].Cells[2].Value = VA[i].GetNumero();
                            dgv_mostrar.Rows[line].Cells[3].Value = VA[i].GetIdade();
                            dgv_mostrar.Rows[line].Cells[4].Value = VA[i].GetSexo();
                            dgv_mostrar.Rows[line].Cells[5].Value = VA[i].GetDatadenascimento().ToShortDateString();
                            dgv_mostrar.Rows[line].Cells[6].Value = VA[i].GetTrabalho();
                            dgv_mostrar.Rows[line].Cells[7].Value = VA[i].GetAnocurricular();
                            dgv_mostrar.Rows[line].Cells[8].Value = VA[i].GetNotas().Mostrarnota1();
                            dgv_mostrar.Rows[line].Cells[9].Value = VA[i].GetNotas().Mostrarnota2();
                            dgv_mostrar.Rows[line].Cells[10].Value = VA[i].GetNotas().Mostrarnota3();
                            dgv_mostrar.Rows[line].Cells[11].Value = VA[i].GetNotas().Mostrarnota4();
                            dgv_mostrar.Rows[line].Cells[12].Value = VA[i].GetNotas().Mostrarnota5();
                        }
                    }
                }
            }
        }

        private void atualizar(object sender, DataGridViewCellEventArgs e)
        {
            int lineIndex = dgv_mostrar.CurrentCell.RowIndex;//coluna seleccionada
            atualizardados_por_id(Convert.ToInt32(dgv_mostrar.Rows[lineIndex].Cells[0].Value));
        }

        private void atualizardados_por_id(int idaluno)
        {
            alunoaalterar = idaluno;
            //receber o id do aluno e vou pegar nos dados dele e colocar na cena para os alterar
            gp_list.Enabled = false;
            gp_aluno.Enabled = true;
            pic_aluno.Enabled = false;
            btn_atualizar_dados.Visible = true;
            btn_cancelar.Visible = true;
            btn_adicionarpessoa.Visible = false;
            btn_limpar.Visible = false;

            //copiar os dados do vetor para as textboxes

            if (VA[idaluno].GetTrabalho() == " Estudante ")
            {
                rb_estudante.Checked = true;
            }
            else
            {
                rb_trabalhadorestudante.Checked = true;
            }

            txt_Nome.Text = VA[idaluno].GetNome();
            txt_numero.Text = Convert.ToString(VA[idaluno].GetNumero());
            txt_anocurricular.Text = Convert.ToString(VA[idaluno].GetAnocurricular());
            txt_notas1.Text = Convert.ToString(VA[idaluno].GetNotas().Mostrarnota1());
            txt_notas2.Text = Convert.ToString(VA[idaluno].GetNotas().Mostrarnota2());
            txt_notas3.Text = Convert.ToString(VA[idaluno].GetNotas().Mostrarnota3());
            txt_notas4.Text = Convert.ToString(VA[idaluno].GetNotas().Mostrarnota4());
            txt_notas5.Text = Convert.ToString(VA[idaluno].GetNotas().Mostrarnota5());
            txt_idade.Text = Convert.ToString(VA[idaluno].GetIdade());

            if (VA[idaluno].GetSexo() == " Homem ")
            {
                rb_homem.Checked = true;
            }
            else
            {
                rb_mulher.Checked = true;
            }
            dtp_datadenascimento.Text = Convert.ToString(VA[idaluno].GetDatadenascimento());      
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            gp_list.Enabled = true;
            gp_aluno.Enabled = false;
            pic_aluno.Enabled = true;
            btn_atualizar_dados.Visible = false;
            btn_cancelar.Visible = false;
            btn_adicionarpessoa.Visible = true;
            btn_limpar.Visible = true;
            alunoaalterar = -1;
            limparinfoaluno();
        }

        private void btn_atualizar_dados_Click(object sender, EventArgs e)
        {
            //atualizar os dados
            if (alunoaalterar != -1) //significa que tenho um aluno e sei qual é
            {
                VA[alunoaalterar].SetNome(txt_Nome.Text);
                VA[alunoaalterar].SetIdade(Convert.ToInt32(txt_idade.Text));
                VA[alunoaalterar].SetDatadenascimento(Convert.ToDateTime(dtp_datadenascimento.Value));
                VA[alunoaalterar].SetNumero(Int32.Parse(txt_numero.Text));
                VA[alunoaalterar].SetAnocurricolar(Int32.Parse(txt_anocurricular.Text));
                if (rb_estudante.Checked)
                {
                    VA[alunoaalterar].SetTrabalho(" Estudante ");
                }
                else
                {
                    VA[alunoaalterar].SetTrabalho(" Trabalhador Estudante ");
                }//fim TRABALHADOR ESTUDANTE

                if (rb_homem.Checked)
                {
                    VA[alunoaalterar].SetSexo("Homem");
                }
                else
                {
                    VA[alunoaalterar].SetSexo("Mulher");
                }//FIM SEXO

                Notas Notas = new Notas(Convert.ToInt32(txt_notas1.Text), Convert.ToInt32(txt_notas2.Text), Convert.ToInt32(txt_notas3.Text), Convert.ToInt32(txt_notas4.Text), Convert.ToInt32(txt_notas5.Text));
                VA[alunoaalterar].SetNotas(Notas);

                //mostrar
                gp_list.Enabled = true;
                gp_aluno.Enabled = false;
                pic_aluno.Enabled = true;
                btn_atualizar_dados.Visible = false;
                btn_cancelar.Visible = false;
                btn_adicionarpessoa.Visible = true;
                btn_limpar.Visible = true;
                MessageBox.Show("Aluno " + txt_Nome.Text + " actualizado com sucesso.");
                mostrar_conteudo();
                limparinfoaluno();
                alunoaalterar = -1;   
            }
            else 
            {
                //mostrar
                gp_list.Enabled = true;
                gp_aluno.Enabled = false;
                pic_aluno.Enabled = true;
                btn_atualizar_dados.Visible = false;
                btn_cancelar.Visible = false;
                btn_adicionarpessoa.Visible = true;
                btn_limpar.Visible = true;
                mostrar_conteudo();
                limparinfoaluno();
                alunoaalterar = -1;
                MessageBox.Show("Erro ao atualizar Aluno", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pic_list_Click(object sender, EventArgs e)
        {
            if (contador < 1 )
            {
                MessageBox.Show("Não existem alunas em lista");
            }
            else
            {
                pic_aluno.Image = Trabalho_pratico_3_final.Properties.Resources.person;
                pic_aluno.Enabled = true;
                pic_list.Image = Trabalho_pratico_3_final.Properties.Resources.list_dis;
                pic_list.Enabled = false;

                gp_list.Enabled = true;
                gp_aluno.Enabled = false;
                limparinfoaluno();           
            }
        }

        private void lb_numeromostrar_Click(object sender, EventArgs e)
        {

        }
    }
}

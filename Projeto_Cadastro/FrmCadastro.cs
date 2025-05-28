using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferenciaDados;

namespace Projeto_Cadastro
{
    public partial class FrmCadastro : Form
    {
        public FrmCadastro()
        {
            InitializeComponent();
        }

        private void mskCEP_Leave(object sender, EventArgs e)
        {
            using (var ws = new WSCorreios.AtendeClienteClient())
            {
                try
                {
                    var resultado = ws.consultaCEP(mskCEP.Text);
                    txtEndereco.Text = resultado.end;
                    txtCidade.Text = resultado.cidade;
                    txtBairro.Text = resultado.bairro;
                    txtEstado.Text = resultado.uf;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == string.Empty) { MessageBox.Show("Favor preencher o campo!!"); txtNome.Focus(); }


            else if (mskCEP.Text == string.Empty)
            {
                MessageBox.Show("Favor preencher o campo!!"); mskCEP.Focus();

            }
            else
            {

                //Instanciar as classes

                InserirCadastro salvarContatos = new InserirCadastro();
                CadastrarDTO dados = new CadastrarDTO();


                //Popular a classe
                dados.COD_FUNC = Convert.ToInt32(txtCodigo.Text);
                dados.NOME = txtNome.Text;
                dados.ENDERECO = txtEndereco.Text;
                dados.CEP = mskCEP.Text;
                dados.BAIRRO = txtBairro.Text;
                dados.CIDADE = txtCidade.Text;
                dados.ESTADO = txtEstado.Text;
                dados.RG = txtRG.Text;
                dados.SALARIO = txtSalario.Text;
                dados.SEXO = rdoM.Text;
                dados.SEXO = rdoF.Text;
                dados.FUNCAO = txtfunc.Text;

                if (rdoM.Checked == true || rdoF.Checked == true)
                {


                    //chamar o método
                    salvarContatos.InserirFuncionario(dados);
                    //Verificar o resultado

                    if (dados.mensagens != null)

                    {
                        //Retorno do código
                        //txtCodigo.Text = dados.mensagens;
                        MessageBox.Show(dados.mensagens, "Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }

                    else

                    {
                        MessageBox.Show("Incluído com sucesso", "Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Escolha um sexo por favor", "Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void FrmCadastro_Load(object sender, EventArgs e)
        {

        }
    }
}


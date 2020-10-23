using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Models
{
    public class Validacao
    {
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }

        public bool Confirma(string Pergunta, string Titulo)
        {
            bool ret = false;

            DialogResult xSimNao = MessageBox.Show(Pergunta, Titulo, MessageBoxButtons.YesNo);
            if (xSimNao == DialogResult.Yes)
            {
                ret = true;
            } else
            {
                ret = false;
            }
            return ret;

        }

        public bool AnalisaMoeda(KeyPressEventArgs e, string pMensagem="")
        {
            //MessageBox.Show(e.KeyChar.ToString());
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                if(!string.IsNullOrEmpty(pMensagem))
                {
                    MessageBox.Show(pMensagem);
                } else { 
                    MessageBox.Show("Somente dígitos e vírgula !");
                }
            }
            return e.Handled;
        }

        public bool AnalisaInteiro(KeyPressEventArgs e, string pMensagem = "")
        {
            //MessageBox.Show(e.KeyChar.ToString());
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(pMensagem))
                {
                    MessageBox.Show(pMensagem);
                }
                else
                {
                    MessageBox.Show("Somente dígitos !");
                }
            }
            return e.Handled;
        }


        public static void RetornarMascara(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = double.Parse(txt.Text).ToString("C2");
        }

        public string Formata_Cep(string txt)
        {
            if (!string.IsNullOrEmpty(txt))
            {

                if (txt.Length == 8 && txt.Substring(5, 1) != "-")
                {
                    txt = Convert.ToUInt64(txt).ToString(@"00000\-000");

                }
            }
            
            return txt;

        }

        public string Formata_TelefoneFixo(string txt)
        {
            if (!string.IsNullOrEmpty(txt))
            {
                if (txt.Length == 10 && txt.Substring(7, 1) != "-")
                {
                    txt = Convert.ToUInt64(txt).ToString(@"\(00\)0000\-0000");

                }
            }
            return txt;

        }
        public string Formata_Celular(string txt)
        {
            if (!string.IsNullOrEmpty(txt))
            {
                if (txt.Length == 11 && txt.Substring(8, 1) != "-")
                {
                    txt = Convert.ToUInt64(txt).ToString(@"\(00\)00000\-0000");

                }
            }
            return txt;

        }

        public string Formata_CNPJ(string txt)
        {
            if (!string.IsNullOrEmpty(txt))
            {
                if (txt.Length == 14 && txt.Substring(2, 1) != ".")
                {
                    txt = Convert.ToUInt64(txt).ToString(@"00\.000\.000\/0000\-00");
                }

               
            }
            return txt;
        }


        public string Formata_CPF(string txt)
        {
            if (!string.IsNullOrEmpty(txt))
            {
                if (txt.Length == 11 && txt.Substring(3, 1) != ".")
                {
                    txt = Convert.ToUInt64(txt).ToString(@"000\.000\.000\-00");
                }
            }
            return txt;
        }

        public string Formata_Moeda(string txt)
        {
           
            if (!string.IsNullOrEmpty(txt))
            {
               // txt = txt.Replace("." , ",");
                
                txt = Convert.ToDouble(txt).ToString("N");

            } else
            {
                txt = "0,00";
            }

            return txt;
        }

        public string ApenasNumeros(string str)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            
            return apenasDigitos.Replace(str, "");
        }

        public void MesInicioFim()
        {
            DateTime Hoje;
            string xAno,xProxAno;
            string xMes,xProxMes;
            DateTime xDataInicial, xDataFinal;

            Hoje = DateTime.Today;
            xAno = Hoje.Year.ToString();
            xMes = Hoje.Month.ToString();
            if(xMes=="12")
            {
                xProxMes = "01";
                xProxAno = ((Hoje.Year) + 1).ToString();
                xDataFinal = DateTime.Parse("01/" + xProxMes + "/" + xProxAno);
            } else
            {
                xProxMes = ((Hoje.Month) + 1).ToString();
                xDataFinal = DateTime.Parse("01/" + xProxMes + "/" + xAno);

            }

            xMes = xMes.ToString().PadLeft(2, '0');

            xDataInicial = DateTime.Parse("01/" + xMes.ToString() + "/" + xAno.ToString());
            xDataInicial = DateTime.Parse("01/" + xMes.ToString() + "/" + xAno.ToString());
            DataInicial = xDataInicial.ToString();
            xDataFinal = xDataFinal.AddDays(-1);
            DataFinal = xDataFinal.ToString();

        }
        /*********************************************************************************** */

        public static string pb_CidadeNome = "FRANCA-SP";  // VARIAVEL PUBLICA PARA A CIDADE PADRAO DO SISTEMA

        /*********************************************************************************** */


        public static String Data_Extenso(DateTime xData)
        {
            return pb_CidadeNome + ", " + xData.Day + " de " + Mes_Extenso(xData) + " de " + xData.Year;
        }

        /*********************************************************************************** */

        public static String Mes_Extenso(DateTime xData)
        {
            int xMes = xData.Month;
            string xExtenso = "";
            switch (xMes)
            {
                case 1:
                    xExtenso = "Janeiro";
                    break;
                case 2:
                    xExtenso = "Fevereiro";
                    break;
                case 3:
                    xExtenso = "Março";
                    break;
                case 4:
                    xExtenso = "Abril";
                    break;
                case 5:
                    xExtenso = "Maio";
                    break;
                case 6:
                    xExtenso = "Junho";
                    break;
                case 7:
                    xExtenso = "Julho";
                    break;
                case 8:
                    xExtenso = "Agosto";
                    break;
                case 9:
                    xExtenso = "Setembro";
                    break;
                case 10:
                    xExtenso = "Outubro";
                    break;
                case 11:
                    xExtenso = "Novembro";
                    break;
                case 12:
                    xExtenso = "Dezembro";
                    break;

            }

            return xExtenso;
        }

        /*********************************************************************************** */
        public Boolean Verifica_CPF(string xCPF)
        {
            if (xCPF.Length < 14)
            {
                return false;
            }
            int[] wCPF = new int[11];
            int[] wPeso = new int[11];
            int[] wP1 = new int[11];
            int[] wP2 = new int[11];
            int wdg1 = 0;
            int wdg2 = 0;
            int wResto1 = 0;
            int wResto2 = 0;
            int wSoma1 = 0;
            int wSoma2 = 0;
            int dg1 = 0;
            int dg2 = 0;

            wPeso[0] = 10;
            wPeso[1] = 9;
            wPeso[2] = 8;
            wPeso[3] = 7;
            wPeso[4] = 6;
            wPeso[5] = 5;
            wPeso[6] = 4;
            wPeso[7] = 3;
            wPeso[8] = 2;

            wCPF[0] = int.Parse(xCPF.Substring(0, 1));
            wCPF[1] = int.Parse(xCPF.Substring(1, 1));
            wCPF[2] = int.Parse(xCPF.Substring(2, 1));
            wCPF[3] = int.Parse(xCPF.Substring(4, 1));
            wCPF[4] = int.Parse(xCPF.Substring(5, 1));
            wCPF[5] = int.Parse(xCPF.Substring(6, 1));
            wCPF[6] = int.Parse(xCPF.Substring(8, 1));
            wCPF[7] = int.Parse(xCPF.Substring(9, 1));
            wCPF[8] = int.Parse(xCPF.Substring(10, 1));
            wCPF[9] = int.Parse(xCPF.Substring(12, 1));

            wdg1 = int.Parse(xCPF.Substring(12, 1));   // o 1. digito verificador digitado ou informado
                                                       //   Console.WriteLine("1. DIGITO INFORMADO:" + wdg1);
            wdg2 = int.Parse(xCPF.Substring(13, 1));   // o 2. digito verificador digitado ou informado
                                                       //   Console.WriteLine("2. DIGITO INFORMADO:" + wdg2);

            for (int z = 0; z < wCPF.Length; z++)
            {


                wP1[z] = wCPF[z] * wPeso[z];

                //       Console.WriteLine((z + 1) + ". digito:" + wCPF[z] + " o total do Peso é: " + wP1[z]);

                wSoma1 = wSoma1 + wP1[z];

            }

            // Console.WriteLine("A somatoria é:" + wSoma1);



            wResto1 = (wSoma1 % 11);
            wResto1 = 11 - wResto1;

            // Console.WriteLine("o resto 1 é:" + wResto1);

            if (wResto1 > 9)
            {
                dg1 = 0;

            }
            else
            {
                dg1 = wResto1;
            }

            // Console.WriteLine("O 1. digito verificador é : " + dg1);

            // remotando array para calculo do 2. digito

            for (int z = 0; z < 10; z++)
            {
                if (z == 0)
                {
                    wPeso[0] = 11;

                }
                else
                {
                    wPeso[z] = 11 - z;

                }

                wP2[z] = wCPF[z] * wPeso[z];


                // Console.WriteLine("O peso de " + wCPF[z] + " é " + wPeso[z]);

                wSoma2 = wSoma2 + wP2[z];
            }

            // Console.WriteLine("A somatoria(2) é:" + wSoma2);

            wResto2 = 0;
            wResto2 = (wSoma2 % 11);
            // Console.WriteLine("O RESTO(2) é:" + wResto2);
            wResto2 = 11 - wResto2;

            if (wResto2 > 9)
            {
                dg2 = 0;

            }
            else
            {
                dg2 = wResto2;
            }

            // Console.WriteLine("O 2º digito verificador é: " + dg2);

            if (dg1 == wdg1 && dg2 == wdg2)
            {
                // Console.WriteLine("CPF INFORMADO É VALIDO !");
                return true;

            }
            else
            {
                // Console.WriteLine("CPF INVÁLIDO !");
                return false;
            }
        }


        public bool Verifica_CNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static void TirarMascara(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = txt.Text.Replace("R$", "").Trim();
        }
        public static void ApenasValorNumerico(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txt.Text.Contains(','));
                }
                else
                    e.Handled = true;
            }
        }

        public static void AplicarEventosValores(TextBox txt)
        {
            txt.Enter += TirarMascara;
            txt.Leave += RetornarMascara;
            txt.KeyPress += ApenasValorNumerico;
        }




    }
}

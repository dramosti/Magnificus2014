using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using ComponentFactory.Krypton.Toolkit;
using System.Windows.Forms;

namespace HLP.Comum.Infrastructure.Static
{
    public static class Util
    {
        public static string ToUpperFirstLetter(string Texto)
        {
            if (Texto == null)
            {
                Texto = "";
            }
            Texto = Texto.ToLower();
            if (string.IsNullOrEmpty(Texto))
                return string.Empty;

            char[] letters = Texto.ToCharArray();

            letters[0] = char.ToUpper(letters[0]);

            return new string(letters);
        }

        public static bool ValidaCnpj(string strCnpj)
        {
            strCnpj = TiraSimbolo(strCnpj, "");

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            strCnpj = strCnpj.Trim();
            strCnpj = strCnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (strCnpj.Length != 14)
                return false;
            tempCnpj = strCnpj.Substring(0, 12);
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
            return strCnpj.EndsWith(digito);
        }

        public static string TiraSimbolo(string strString, string strIgnorar)
        {

            string[,] sSimbolos = {   
                                    { "á", "a" },
                                    { "Á", "A" },
                                    { "é", "e" },
                                    { "É", "E" },
                                    { "í", "i" },
                                    { "Í", "I" },
                                    { "ó", "o" },
                                    { "Ó", "O" },
                                    { "ú", "u" },
                                    { "Ú", "U" },
                                    { "ã", "a" },
                                    { "Ã", "A" },
                                    { "õ", "o" },
                                    { "Õ", "O" },
                                    { "â", "a" },
                                    { "Â", "A" },
                                    { "ê", "e" },
                                    { "Ê", "E" },
                                    { "ô", "o" },
                                    { "Ô", "O" },
                                    { "/", "" },
                                    { "ç", "c" },
                                    { "Ç", "C" },
                                    { "-", "" },
                                    { "_cod_seq_par_financ", "" },
                                    { "  ", "" },
                                    { ".", "" },
                                    { "(", "" },
                                    { ")", "" },
                                    { "°", "o" },
                                    { "�", " "},
                                    { "&", "E"},
                                    { "*", ""},
                                    { "º", "o"},
                                    { "\"", ""},
                                    { "Ø", ""},
                                    { "'", ""},
                                    { ")", "" },
                                    { ",", ""},
                                    { " ", ""}
                                };

            string Resultado = "";
            string sCar = "";

            for (int i = 0; i <= (strString.Length - 1); i++)
            {
                sCar = strString[i].ToString();
                for (int y = 0; y <= (sSimbolos.GetLength(0) - 1); y++)
                {
                    if ((sCar == sSimbolos[y, 0]) && (sCar != strIgnorar))
                    {
                        strString = strString.Replace(sCar, sSimbolos[y, 1]);
                    }
                }

            }


            Resultado = strString;

            return Resultado;
        }

        public static bool ValidaCpf(string strCpf)
        {

            strCpf = TiraSimbolo(strCpf, "");

            if (strCpf.ToArray().Distinct().Count() == 1)
            {
                return false;
            }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;

            int soma;
            int resto;

            strCpf = strCpf.Trim();
            strCpf = strCpf.Replace(".", "").Replace("-", "");

            if (strCpf.Length != 11)
            {
                return false;
            }
            tempCpf = strCpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * (multiplicador1[i]);
            }
            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            int soma2 = 0;

            for (int i = 0; i < 10; i++)
            {
                soma2 += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma2 % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();
            return strCpf.EndsWith(digito);
        }

        public static Byte[] ImagemParaByte(string strFileName)
        {
            FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            return (br.ReadBytes(Convert.ToInt32(br.BaseStream.Length)));
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            if (byteArrayIn != null)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                returnImage = Image.FromStream(ms);
            }
            return returnImage;
        }

        public static string ComputeHash(string plainText, string hashAlgorithm, byte[] saltBytes)
        {
            // If salt is not specified, generate it on the fly.
            if (saltBytes == null)
            {
                // Define min and max salt sizes.
                int minSaltSize = 1;
                int maxSaltSize = 10;

                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);
            }

            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes =
                    new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            // Because we support multiple hashing algorithms, we must define
            // hash object as a common (abstract) base class. We will specify the
            // actual hashing algorithm class later during object creation.
            HashAlgorithm hash;

            // Make sure hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Initialize appropriate hashing algorithm class.
            switch (hashAlgorithm.ToUpper())
            {
                case "SHA1":
                    hash = new SHA1Managed();
                    break;

                case "SHA256":
                    hash = new SHA256Managed();
                    break;

                case "SHA384":
                    hash = new SHA384Managed();
                    break;

                case "SHA512":
                    hash = new SHA512Managed();
                    break;

                default:
                    hash = new MD5CryptoServiceProvider(); //MD5
                    break;
            }

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length +
                                                saltBytes.Length];

            // Copy hash bytes into resulting array.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            return hashValue;
        }

        public static bool VerifyHash(string plainText, string hashAlgorithm, string hashValue)
        {
            // Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

            // We must know size of hash (without salt).
            int hashSizeInBits, hashSizeInBytes;

            // Make sure that hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Size of hash is based on the specified algorithm.
            switch (hashAlgorithm.ToUpper())
            {
                case "SHA1":
                    hashSizeInBits = 160;
                    break;

                case "SHA256":
                    hashSizeInBits = 256;
                    break;

                case "SHA384":
                    hashSizeInBits = 384;
                    break;

                case "SHA512":
                    hashSizeInBits = 512;
                    break;

                default: // Must be MD5
                    hashSizeInBits = 128;
                    break;
            }

            // Convert size of hash from bits to bytes.
            hashSizeInBytes = hashSizeInBits / 8;

            // Make sure that the specified hash value is long enough.
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;

            // Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length -
                                        hashSizeInBytes];

            // Copy salt from the end of the hash to the new array.
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

            // Compute a new hash string.
            string expectedHashString =
                        ComputeHash(plainText, hashAlgorithm, saltBytes);

            // If the computed hash matches the specified hash,
            // the plain text value must be correct.
            return (hashValue == expectedHashString);
        }

        public static bool ValidaData(string sData)
        {
            Regex m = new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");
            if (m.IsMatch(sData))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidaNumeroTinyInt(string sNum)
        {
            Regex m = new Regex("^([0-9]+)$");
            if (m.IsMatch(sNum))
            {
                try
                {
                    Convert.ToByte(sNum);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public static bool ValidaNumeroInteiro(string sNum)
        {
            Regex m = new Regex("^([0-9]+)$");
            if (m.IsMatch(sNum))
            {
                try
                {
                    Convert.ToInt32(sNum);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gera o Regex de acordo com a mascara citada no parametro
        /// </summary>
        /// <param name="sMascara"></param>
        /// <returns></returns>
        public static string GeraRegexDecimal(string sMascara)
        {
            int count = 0;
            string maskRegex = "^";
            for (int i = 0; i < sMascara.Length; i++)
            {

                if (sMascara[i] == '.')
                {
                    maskRegex += "[0-9]{1," + count + "}";
                    if (count == i)
                    {
                        maskRegex += "[.]";
                    }

                    count = 0;
                }
                else
                {
                    count++;
                }
            }
            maskRegex += "[0-9]{1," + count + "}$";
            return maskRegex;
        }

        /// <summary>
        /// Formata a Valor decimal de acordo com os parametros
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="interiros"></param>
        /// <param name="decimais"></param>
        /// <returns></returns>
        public static string FormataValorDecimal(string valor, string interiros, string decimais)
        {
            interiros = "{1," + interiros + "}";
            string zeros = "0";
            for (int i = 0; i < (Convert.ToInt32(decimais) - 1); i++)
            {
                zeros += "0";
            }
            string sValorFormatado = "";
            Regex m1 = new Regex("^[0-9]" + interiros + "[.]$");
            Regex m2 = new Regex("^[0-9]" + interiros + "$");
            Regex m3 = new Regex("^[.][0-9]{" + decimais + "}$");


            int count = 0;
            for (int i = 0; i < valor.Length; i++)
            {
                if (count > 0)
                {
                    count += 1;
                }
                if ((valor[i].ToString().Equals(",")) || (valor[i].ToString().Equals(".")))
                {
                    count = 1;
                }
            }
            if (count == 0)
            {
                valor = valor + "." + zeros;

            }
            else if ((count - 1) < Convert.ToInt32(decimais))
            {
                for (int i = 0; i < (Convert.ToInt32(decimais) - (count - 1)); i++)
                {
                    valor = valor + "0";
                }
            }


            if (m1.IsMatch(valor) == true)
            {
                sValorFormatado = valor + zeros;
            }
            else if (m2.IsMatch(valor) == true)
            {
                sValorFormatado = valor + "." + zeros;
            }
            else if (m3.IsMatch(valor) == true)
            {
                sValorFormatado = "0" + valor;
            }
            else
            {
                sValorFormatado = valor;
            }
            return sValorFormatado;

        }


        public static bool ValidaHora(decimal dvalor)
        {
            int isegundos = Convert.ToInt32((dvalor - Math.Truncate(dvalor)) * 100);

            if (isegundos > 59)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static decimal RetTotalMinutosSegundos(decimal objListHoras)
        {
            int itotMinutos = 0;
            int itotSegundos = 0;

            itotMinutos += Convert.ToInt32(Math.Truncate(objListHoras));
            itotSegundos += Convert.ToInt32((objListHoras - Math.Truncate(objListHoras)) * 100);

            if (itotSegundos / 60 > 0)
            {
                itotMinutos += Convert.ToInt32(itotSegundos / 60);

                itotSegundos = itotSegundos - (Convert.ToInt32(itotSegundos / 60) * 60);
            }
            if (itotSegundos > 9)
            {
                return Convert.ToDecimal(itotMinutos.ToString() + "," + itotSegundos.ToString());
            }
            else
            {
                return Convert.ToDecimal(itotMinutos.ToString() + ",0" + itotSegundos.ToString());
            }
        }

        public static decimal RetTotalMinutosSegundos(List<decimal> objListHoras)
        {
            int itotMinutos = 0;
            int itotSegundos = 0;

            for (int i = 0; i < objListHoras.Count; i++)
            {
                itotMinutos += Convert.ToInt32(Math.Truncate(objListHoras[i]));
                itotSegundos += Convert.ToInt32((objListHoras[i] - Math.Truncate(objListHoras[i])) * 100);
            }

            if (itotSegundos / 60 > 0)
            {
                itotMinutos += Convert.ToInt32(itotSegundos / 60);

                itotSegundos = itotSegundos - (Convert.ToInt32(itotSegundos / 60) * 60);
            }
            if (itotSegundos > 9)
            {
                return Convert.ToDecimal(itotMinutos.ToString() + "," + itotSegundos.ToString());
            }
            else
            {
                return Convert.ToDecimal(itotMinutos.ToString() + ",0" + itotSegundos.ToString());
            }
        }

        public static string RetHoras(decimal dValorHoras)
        {
            int itotMinutos = 0;
            int itotSegundos = 0;
            int iHoras = 0;

            string stotMinutos = "";
            string stotSegundos = "";
            string sHoras = "";

            #region Calculo Horas
            itotMinutos = Convert.ToInt32(Math.Truncate(dValorHoras));
            itotSegundos = Convert.ToInt32((dValorHoras - Math.Truncate(dValorHoras)) * 100);

            if (itotSegundos / 60 > 0)
            {
                itotMinutos = Convert.ToInt32(itotSegundos / 60);

                itotSegundos = itotSegundos - (Convert.ToInt32(itotSegundos / 60) * 60);
            }

            if (itotMinutos / 60 > 0)
            {
                iHoras = Convert.ToInt16(itotMinutos / 60);

                itotMinutos = itotMinutos - (Convert.ToInt32(itotMinutos / 60) * 60);
            }



            if (itotSegundos > 9)
            {
                stotSegundos = (itotSegundos.ToString());
            }
            else
            {
                stotSegundos = "0" + itotSegundos.ToString();
            }

            if (itotMinutos > 9)
            {
                stotMinutos = (itotMinutos.ToString());
            }
            else
            {
                stotMinutos = ("0" + itotMinutos.ToString());
            }
            if (iHoras > 9)
            {
                sHoras = (iHoras.ToString());
            }
            else
            {
                sHoras = ("0" + iHoras.ToString());
            }

            #endregion

            return sHoras + ":" + stotMinutos + ":" + stotSegundos;
        }

        //public static List<boPesquisaPadrao> BuscaListaCampos(XmlDocument xml)
        //{
        //    try
        //    {
        //        List<boPesquisaPadrao> objListaReturn = new List<boPesquisaPadrao>();
        //        XmlNodeList xNodeList = xml.GetElementsByTagName("Filtro");
        //        foreach (XmlNode node in xNodeList)
        //        {
        //            objListaReturn.Add(
        //                new boPesquisaPadrao { clmCampo = node["clmCampo"].InnerText, DescrCampo = node["DescrCampo"].InnerText, TipoCampo = node["TipoCampo"].InnerText });
        //        }
        //        return objListaReturn;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public static List<boPesquisaPadrao> BuscaListaChaves(XmlDocument xml)
        //{
        //    try
        //    {
        //        List<boPesquisaPadrao> objListaReturn = new List<boPesquisaPadrao>();
        //        XmlNodeList xNodeList = xml.GetElementsByTagName("Chave");
        //        foreach (XmlNode node in xNodeList)
        //        {
        //            objListaReturn.Add(
        //                new boPesquisaPadrao { clmCampo = node["clmCampo"].InnerText, DescrCampo = node["DescrCampo"].InnerText, TipoCampo = node["TipoCampo"].InnerText });
        //        }
        //        return objListaReturn;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}       

        public static bool ValidaDecimal(string valor, string interiros, string decimais)
        {
            Regex rg = new Regex(@"^[0-9]{1," + interiros + @"}(\,\d{0," + decimais + "})?$");
            bool bValida = rg.IsMatch(valor);
            return bValida;
        }

        public static bool ValidaInteiro(string sValor)
        {
            Regex rg = new Regex("^[0-9]{1,9}$");
            if (rg.IsMatch(sValor))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Valida se o caminho existe e caso não, cria o mesmo.
        /// </summary>
        public static string ValidaCaminho(string sCaminho)
        {
            DirectoryInfo dinfo = new DirectoryInfo(sCaminho);
            if (!dinfo.Exists)
            {
                dinfo.Create();
            }
            return dinfo.FullName;
        }

        [DllImport("DllInscE32.dll")]
        private static extern int ConsisteInscricaoEstadual(string vInsc, string vUF);

        //Verificar IE / Parametro1 = Inscrição / Parametro2 = Estado
        public static bool IE(string nInsc, string sUF)
        {
            nInsc = TiraSimbolo(nInsc, "");
            //Caso a Inscricão e o Estado Estejam Certos, Retorna Verdadeiro
            if (Convert.ToBoolean(ConsisteInscricaoEstadual(nInsc, sUF))) return true;
            else return false;
        }


        [DllImport("Kernel32")]
        public extern static int LoadLibrary(string spLibFileName);

        public static bool isDllRegitered(string sDllName)
        {
            int libId = LoadLibrary(sDllName);

            if (libId == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Color ConverteCor(string sCor)
        {
            try
            {
                Color cor;
                if (sCor == null)
                {
                    sCor = Color.White.Name.ToString();
                }
                if (sCor.StartsWith("#"))
                {
                    cor = ColorTranslator.FromHtml(sCor);
                }
                else
                {
                    ColorConverter color = new ColorConverter();
                    cor = (Color)color.ConvertFromString(sCor);
                }
                return cor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExportarExcel(KryptonDataGridView grdDados)
        {
            Microsoft.Office.Interop.Excel.Application excelapp =
    new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook =
                excelapp.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            excelapp.Visible = true;
            try
            {
                string sText = "HLP";
                Control ctr = grdDados.Parent;
                while (ctr.Parent != null)
                {
                    if (ctr.GetType() == typeof(TabPage))
                    {
                        sText = ((TabPage)ctr).Text;
                        break;
                    }
                    ctr = ctr.Parent;
                }
                // pegando a primeira planilha do excel;
                // deixando-a como ativa e ao final,
                // será atribuido um nome a ela.
                worksheet = (Worksheet)workbook.Sheets["Plan1"];
                worksheet = (Worksheet)workbook.ActiveSheet;
                worksheet.Name = sText;

                // pegando os nomes das colunas do DataGridView
                for (int i = 1; i < grdDados.Columns.Count + 1; i++)
                {
                    if (grdDados.Columns[i - 1].Visible == true)
                    {
                        worksheet.Cells[1, i] =
                            grdDados.Columns[i - 1].HeaderText;
                    }
                }

                // fazendo um loop no DataGridView, que recupera as rows
                // do DataGridView, correspondente a cada column.
                for (int i = 0; i < grdDados.RowCount; i++)
                {
                    for (int j = 0; j < grdDados.Columns.Count; j++)
                    {
                        if (grdDados.Columns[j].Visible == true)
                        {
                            if (grdDados.Rows[i].Cells[j].GetType() == typeof(System.Windows.Forms.DataGridViewComboBoxCell))
                            {
                                if (grdDados.Rows[i].Cells[j].Value != null)
                                {
                                    string Display = grdDados.Rows[i].Cells[j].EditedFormattedValue.ToString();
                                    worksheet.Cells[i + 2, j + 1] = Display;
                                }
                                else
                                {
                                    worksheet.Cells[i + 2, j + 1] = "";
                                }
                            }
                            else if (grdDados.Rows[i].Cells[j].GetType() == typeof(KryptonDataGridViewNumericUpDownCell))
                            {
                                worksheet.Cells[i + 2, j + 1] = grdDados.Rows[i].Cells[j].Value != null ? grdDados.Rows[i].Cells[j].Value.ToString().Replace(",", ".") : "";
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = grdDados.Rows[i].Cells[j].Value != null ? grdDados.Rows[i].Cells[j].Value.ToString() : "";
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /* Valida Incrição estadual*/
        public static bool ValidarInscricaoEstadual(string pInscr, string pUF)
        {
            bool retorno = false;
            string strBase;
            string strBase2;
            string strOrigem;
            string strDigito1;
            string strDigito2;
            int intPos;
            int intValor;
            int intSoma = 0;
            int intResto;
            int intNumero;
            int intPeso = 0;

            strBase = "";
            strBase2 = "";
            strOrigem = "";

            if (pInscr.ToUpper() == "ISENTO") return true;

            if ((pInscr.Trim().Length <= 0)) return false;

            for (intPos = 1; intPos <= pInscr.Trim().Length; intPos++)
            {
                if ((("0123456789P".IndexOf(pInscr.Substring((intPos - 1), 1), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0))
                    strOrigem = (strOrigem + pInscr.Substring((intPos - 1), 1));
            }

            switch (pUF.ToUpper())
            {
                case "AC":
                    #region

                    strBase = (strOrigem.Trim() + "00000000000").Substring(0, 11);

                    if (strBase.Substring(0, 2) == "01")
                    {
                        intSoma = 0;
                        intPeso = 4;

                        for (intPos = 1; (intPos <= 11); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            if (intPeso == 1) intPeso = 9;

                            intSoma += intValor * intPeso;

                            intPeso--;
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        intSoma = 0;
                        strBase = (strOrigem.Trim() + "000000000000").Substring(0, 12);
                        intPeso = 5;

                        for (intPos = 1; (intPos <= 12); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            if (intPeso == 1) intPeso = 9;

                            intSoma += intValor * intPeso;
                            intPeso--;
                        }

                        intResto = (intSoma % 11);
                        strDigito2 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        strBase2 = (strBase.Substring(0, 12) + strDigito2);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }
                    #endregion

                    break;

                case "AL":

                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "24"))
                    {
                        //24000004-8
                        //98765432
                        intSoma = 0;
                        intPeso = 9;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            intSoma += intValor * intPeso;
                            intPeso--;
                        }

                        intSoma = (intSoma * 10);
                        intResto = (intSoma % 11);

                        strDigito1 = ((intResto == 10) ? "0" : Convert.ToString(intResto)).Substring((((intResto == 10) ? "0" : Convert.ToString(intResto)).Length - 1));

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case "AM":

                    #region
                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intSoma = 0;
                    intPeso = 9;

                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                        intSoma += intValor * intPeso;
                        intPeso--;
                    }

                    intResto = (intSoma % 11);

                    if (intSoma < 11)
                        strDigito1 = (11 - intSoma).ToString();
                    else
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;
                    #endregion

                    break;

                case "AP":

                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intPeso = 9;

                    if ((strBase.Substring(0, 2) == "03"))
                    {
                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            intSoma += intValor * intPeso;
                            intPeso--;
                        }

                        intResto = (intSoma % 11);
                        intValor = (11 - intResto);

                        strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case "BA":

                    #region

                    if (strOrigem.Length == 8)
                        strBase = (strOrigem.Trim() + "00000000").Substring(0, 8);
                    else if (strOrigem.Length == 9)
                        strBase = (strOrigem.Trim() + "00000000").Substring(0, 9);

                    if ((("0123458".IndexOf(strBase.Substring(0, 1), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0) && strBase.Length == 8)
                    {
                        #region

                        intSoma = 0;

                        for (intPos = 1; (intPos <= 6); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            if (intPos == 1) intPeso = 7;

                            intSoma += intValor * intPeso;
                            intPeso--;
                        }


                        intResto = (intSoma % 10);
                        strDigito2 = ((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Length - 1));


                        strBase2 = strBase.Substring(0, 7) + strDigito2;

                        if (strBase2 == strOrigem)
                            retorno = true;

                        if (retorno)
                        {
                            intSoma = 0;
                            intPeso = 0;

                            for (intPos = 1; (intPos <= 7); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                if (intPos == 7)
                                    intValor = int.Parse(strBase.Substring((intPos), 1));

                                if (intPos == 1) intPeso = 8;

                                intSoma += intValor * intPeso;
                                intPeso--;
                            }


                            intResto = (intSoma % 10);
                            strDigito1 = ((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Length - 1));

                            strBase2 = (strBase.Substring(0, 6) + strDigito1 + strDigito2);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                    }
                    else if ((("679".IndexOf(strBase.Substring(0, 1), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0) && strBase.Length == 8)
                    {
                        #region

                        intSoma = 0;

                        for (intPos = 1; (intPos <= 6); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            if (intPos == 1) intPeso = 7;

                            intSoma += intValor * intPeso;
                            intPeso--;
                        }


                        intResto = (intSoma % 11);
                        strDigito2 = ((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Length - 1));


                        strBase2 = strBase.Substring(0, 7) + strDigito2;

                        if (strBase2 == strOrigem)
                            retorno = true;

                        if (retorno)
                        {
                            intSoma = 0;
                            intPeso = 0;

                            for (intPos = 1; (intPos <= 7); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                if (intPos == 7)
                                    intValor = int.Parse(strBase.Substring((intPos), 1));

                                if (intPos == 1) intPeso = 8;

                                intSoma += intValor * intPeso;
                                intPeso--;
                            }


                            intResto = (intSoma % 11);
                            strDigito1 = ((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                            strBase2 = (strBase.Substring(0, 6) + strDigito1 + strDigito2);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                    }
                    else if ((("0123458".IndexOf(strBase.Substring(1, 1), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0) && strBase.Length == 9)
                    {
                        #region
                        /* Segundo digito */
                        //1000003
                        //8765432
                        intSoma = 0;


                        for (intPos = 1; (intPos <= 7); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            if (intPos == 1) intPeso = 8;

                            intSoma += intValor * intPeso;
                            intPeso--;
                        }

                        intResto = (intSoma % 10);
                        strDigito2 = ((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((10 - intResto))).Length - 1));

                        strBase2 = strBase.Substring(0, 8) + strDigito2;

                        if (strBase2 == strOrigem)
                            retorno = true;

                        if (retorno)
                        {
                            //1000003 6
                            //9876543 2
                            intSoma = 0;
                            intPeso = 0;

                            for (intPos = 1; (intPos <= 8); intPos++)
                            {
                                intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                                if (intPos == 8)
                                    intValor = int.Parse(strBase.Substring((intPos), 1));

                                if (intPos == 1) intPeso = 9;

                                intSoma += intValor * intPeso;
                                intPeso--;
                            }


                            intResto = (intSoma % 10);
                            strDigito1 = ((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto == 0) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                            strBase2 = (strBase.Substring(0, 7) + strDigito1 + strDigito2);

                            if ((strBase2 == strOrigem))
                                retorno = true;
                        }

                        #endregion
                    }

                    #endregion

                    break;

                case "CE":

                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    intValor = (11 - intResto);

                    if ((intValor > 9))
                        intValor = 0;

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));

                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case "DF":

                    #region

                    strBase = (strOrigem.Trim() + "0000000000000").Substring(0, 13);

                    if ((strBase.Substring(0, 3) == "073"))
                    {
                        intSoma = 0;
                        intPeso = 2;

                        for (intPos = 11; (intPos >= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso > 9))
                                intPeso = 2;
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 11) + strDigito1);
                        intSoma = 0;
                        intPeso = 2;

                        for (intPos = 12; (intPos >= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso > 9))
                                intPeso = 2;
                        }

                        intResto = (intSoma % 11);
                        strDigito2 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 12) + strDigito2);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case "ES":

                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case "GO":

                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((("10,11,15".IndexOf(strBase.Substring(0, 2), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0))
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);

                        if ((intResto == 0))
                            strDigito1 = "0";
                        else if ((intResto == 1))
                        {
                            intNumero = int.Parse(strBase.Substring(0, 8));
                            strDigito1 = (((intNumero >= 10103105) && (intNumero <= 10119997)) ? "1" : "0").Substring(((((intNumero >= 10103105) && (intNumero <= 10119997)) ? "1" : "0").Length - 1));
                        }
                        else
                            strDigito1 = Convert.ToString((11 - intResto)).Substring((Convert.ToString((11 - intResto)).Length - 1));

                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case "MA":

                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "12"))
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case "MT":
                    #region

                    strBase = (strOrigem.Trim() + "0000000000").Substring(0, 10);
                    intSoma = 0;
                    intPeso = 2;

                    for (intPos = 10; intPos >= 1; intPos = (intPos + -1))
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * intPeso);
                        intSoma = (intSoma + intValor);
                        intPeso = (intPeso + 1);

                        if ((intPeso > 9))
                            intPeso = 2;
                    }

                    intResto = (intSoma % 11);
                    strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase.Substring(0, 10) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;
                case "MS":
                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "28"))
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case "MG":

                    #region

                    strBase = (strOrigem.Trim() + "0000000000000").Substring(0, 13);
                    strBase2 = (strBase.Substring(0, 3) + ("0" + strBase.Substring(3, 8)));
                    intNumero = 2;

                    string strSoma = "";

                    for (intPos = 1; (intPos <= 12); intPos++)
                    {
                        intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                        intNumero = ((intNumero == 2) ? 1 : 2);
                        intValor = (intValor * intNumero);

                        intSoma = (intSoma + intValor);
                        strSoma += intValor.ToString();
                    }

                    intSoma = 0;

                    //Soma -se os algarismos, não o produto
                    for (int i = 0; i < strSoma.Length; i++)
                    {
                        intSoma += int.Parse(strSoma.Substring(i, 1));
                    }

                    intValor = int.Parse(strBase.Substring(8, 2));
                    strDigito1 = (intValor - intSoma).ToString();

                    strBase2 = (strBase.Substring(0, 11) + strDigito1);

                    if ((strBase2 == strOrigem.Substring(0, 12)))
                        retorno = true;

                    if (retorno)
                    {
                        intSoma = 0;
                        intPeso = 3;

                        for (intPos = 1; (intPos <= 12); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));

                            if (intPeso < 2)
                                intPeso = 11;

                            intSoma += (intValor * intPeso);
                            intPeso--;
                        }

                        intResto = (intSoma % 11);
                        intValor = 11 - intResto;
                        strDigito2 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));

                        strBase2 = (strBase.Substring(0, 12) + strDigito2);

                        if (strBase2 == strOrigem)
                            retorno = true;
                    }

                    #endregion

                    break;

                case "PA":

                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "15"))
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case "PB":

                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    intValor = (11 - intResto);

                    if ((intValor > 9))
                        intValor = 0;

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case "PE":
                    #region

                    strBase = (strOrigem.Trim() + "00000000000000").Substring(0, 14);
                    intSoma = 0;
                    intPeso = 2;

                    for (intPos = 7; (intPos >= 1); intPos = (intPos + -1))
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * intPeso);
                        intSoma = (intSoma + intValor);
                        intPeso = (intPeso + 1);

                        if ((intPeso > 9))
                            intPeso = 2;
                    }

                    intResto = (intSoma % 11);
                    intValor = (11 - intResto);

                    if ((intValor > 9))
                        intValor = (intValor - 10);

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                    strBase2 = (strBase.Substring(0, 7) + strDigito1);

                    if ((strBase2 == strOrigem.Substring(0, 8)))
                        retorno = true;

                    if (retorno)
                    {
                        intSoma = 0;
                        intPeso = 2;

                        for (intPos = 8; (intPos >= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso > 9))
                                intPeso = 2;
                        }

                        intResto = (intSoma % 11);
                        intValor = (11 - intResto);

                        if ((intValor > 9))
                            intValor = (intValor - 10);

                        strDigito2 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito2);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case "PI":
                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case "PR":
                    #region

                    strBase = (strOrigem.Trim() + "0000000000").Substring(0, 10);
                    intSoma = 0;
                    intPeso = 2;

                    for (intPos = 8; (intPos >= 1); intPos = (intPos + -1))
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * intPeso);
                        intSoma = (intSoma + intValor);
                        intPeso = (intPeso + 1);

                        if ((intPeso > 7))
                            intPeso = 2;
                    }

                    intResto = (intSoma % 11);
                    strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);
                    intSoma = 0;
                    intPeso = 2;

                    for (intPos = 9; (intPos >= 1); intPos = (intPos + -1))
                    {
                        intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                        intValor = (intValor * intPeso);
                        intSoma = (intSoma + intValor);
                        intPeso = (intPeso + 1);

                        if ((intPeso > 7))
                            intPeso = 2;
                    }

                    intResto = (intSoma % 11);
                    strDigito2 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase2 + strDigito2);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case "RJ":
                    #region

                    strBase = (strOrigem.Trim() + "00000000").Substring(0, 8);
                    intSoma = 0;
                    intPeso = 2;

                    for (intPos = 7; (intPos >= 1); intPos = (intPos + -1))
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * intPeso);
                        intSoma = (intSoma + intValor);
                        intPeso = (intPeso + 1);

                        if ((intPeso > 7))
                            intPeso = 2;
                    }

                    intResto = (intSoma % 11);
                    strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase.Substring(0, 7) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case "RN": //Verficar com 10 digitos
                    #region

                    if (strOrigem.Length == 9)
                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    else if (strOrigem.Length == 10)
                        strBase = (strOrigem.Trim() + "000000000").Substring(0, 10);

                    if ((strBase.Substring(0, 2) == "20") && strBase.Length == 9)
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intSoma = (intSoma * 10);
                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto > 9) ? "0" : Convert.ToString(intResto)).Substring((((intResto > 9) ? "0" : Convert.ToString(intResto)).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }
                    else if (strBase.Length == 10)
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 9); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * (11 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intSoma = (intSoma * 10);
                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto > 10) ? "0" : Convert.ToString(intResto)).Substring((((intResto > 10) ? "0" : Convert.ToString(intResto)).Length - 1));
                        strBase2 = (strBase.Substring(0, 9) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case "RO":
                    #region
                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    strBase2 = strBase.Substring(3, 5);
                    intSoma = 0;

                    for (intPos = 1; (intPos <= 5); intPos++)
                    {
                        intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                        intValor = (intValor * (7 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    intValor = (11 - intResto);

                    if ((intValor > 9))
                        intValor = (intValor - 10);

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion
                    break;

                case "RR":
                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);

                    if ((strBase.Substring(0, 2) == "24"))
                    {
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = intValor * intPos;
                            intSoma += intValor;
                        }

                        intResto = (intSoma % 9);
                        strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case "RS":
                    #region

                    strBase = (strOrigem.Trim() + "0000000000").Substring(0, 10);
                    intNumero = int.Parse(strBase.Substring(0, 3));

                    if (((intNumero > 0) && (intNumero < 468)))
                    {
                        intSoma = 0;
                        intPeso = 2;

                        for (intPos = 9; (intPos >= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso > 9))
                                intPeso = 2;
                        }

                        intResto = (intSoma % 11);
                        intValor = (11 - intResto);

                        if ((intValor > 9))
                            intValor = 0;

                        strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                        strBase2 = (strBase.Substring(0, 9) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

                case "SC":
                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;
                    #endregion

                    break;

                case "SE":
                    #region

                    strBase = (strOrigem.Trim() + "000000000").Substring(0, 9);
                    intSoma = 0;

                    for (intPos = 1; (intPos <= 8); intPos++)
                    {
                        intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                        intValor = (intValor * (10 - intPos));
                        intSoma = (intSoma + intValor);
                    }

                    intResto = (intSoma % 11);
                    intValor = (11 - intResto);

                    if ((intValor > 9))
                        intValor = 0;

                    strDigito1 = Convert.ToString(intValor).Substring((Convert.ToString(intValor).Length - 1));
                    strBase2 = (strBase.Substring(0, 8) + strDigito1);

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case "SP":
                    #region

                    if ((strOrigem.Substring(0, 1) == "P"))
                    {
                        strBase = (strOrigem.Trim() + "0000000000000").Substring(0, 13);
                        strBase2 = strBase.Substring(1, 8);
                        intSoma = 0;
                        intPeso = 1;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso == 2))
                                intPeso = 3;

                            if ((intPeso == 9))
                                intPeso = 10;
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                        strBase2 = (strBase.Substring(0, 9) + (strDigito1 + strBase.Substring(10, 3)));
                    }
                    else
                    {
                        strBase = (strOrigem.Trim() + "000000000000").Substring(0, 12);
                        intSoma = 0;
                        intPeso = 1;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso == 2))
                                intPeso = 3;

                            if ((intPeso == 9))
                                intPeso = 10;
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                        strBase2 = (strBase.Substring(0, 8) + (strDigito1 + strBase.Substring(9, 2)));
                        intSoma = 0;
                        intPeso = 2;

                        for (intPos = 11; (intPos >= 1); intPos = (intPos + -1))
                        {
                            intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                            intValor = (intValor * intPeso);
                            intSoma = (intSoma + intValor);
                            intPeso = (intPeso + 1);

                            if ((intPeso > 10))
                                intPeso = 2;
                        }

                        intResto = (intSoma % 11);
                        strDigito2 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                        strBase2 = (strBase2 + strDigito2);
                    }

                    if ((strBase2 == strOrigem))
                        retorno = true;

                    #endregion

                    break;

                case "TO":
                    #region

                    strBase = (strOrigem.Trim() + "00000000000").Substring(0, 11);

                    if ((("01,02,03,99".IndexOf(strBase.Substring(2, 2), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0))
                    {
                        strBase2 = (strBase.Substring(0, 2) + strBase.Substring(4, 6));
                        intSoma = 0;

                        for (intPos = 1; (intPos <= 8); intPos++)
                        {
                            intValor = int.Parse(strBase2.Substring((intPos - 1), 1));
                            intValor = (intValor * (10 - intPos));
                            intSoma = (intSoma + intValor);
                        }

                        intResto = (intSoma % 11);
                        strDigito1 = ((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Substring((((intResto < 2) ? "0" : Convert.ToString((11 - intResto))).Length - 1));
                        strBase2 = (strBase.Substring(0, 10) + strDigito1);

                        if ((strBase2 == strOrigem))
                            retorno = true;
                    }

                    #endregion

                    break;

            }

            return retorno;
        }

               public static List<PadraoComboBox> MontaListPadraoComboBox(List<string> lItens)
        {
            List<PadraoComboBox> lRetorno = new List<PadraoComboBox>();
            int icount = 0;
            foreach (string item in lItens)
            {
                lRetorno.Add(new PadraoComboBox { Display = item, value = (Byte)icount });
                icount++;
            }
            return lRetorno;
        }

        public struct PadraoComboBox
        {
            public Byte value { get; set; }
            public string Display { get; set; }
        }
        public static class TextBoxEx
        {
            private const uint ECM_FIRST = 0x1500;
            private const uint EM_SETCUEBANNER = ECM_FIRST + 1;

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
            private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

            public static void SetWatermark(System.Windows.Forms.TextBox textBox, string watermarkText)
            {
                SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermarkText);
            }

        }
    }
}

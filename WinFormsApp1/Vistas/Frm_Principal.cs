using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.Vistas
{
    public partial class Frm_Principal : Form
    {
        DataTable dt_desiciones = new DataTable();
        DataTable dt_Maximos = new DataTable();
        DataTable dt_Minimos = new DataTable();
        DataTable dt_hurwitz = new DataTable();
        public Frm_Principal()
        {
            InitializeComponent();
            this.Text = "Formulario Principal";
            Lab_Titulo.Text = "Investigacion de operaciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            Met_LlenarDatos();
            Met_CrearCamposTablasPublicas();
        }
        #region
        //metodos propios
        private void Met_CrearCamposTablasPublicas() {
            dt_desiciones.Columns.Add("Nombre", typeof(String));

            dt_Maximos.Columns.Add("Nombre", typeof(string));
            dt_Maximos.Columns.Add("Valor", typeof(decimal));

            dt_Minimos.Columns.Add("Nombre", typeof(string));
            dt_Minimos.Columns.Add("Valor", typeof(decimal));

            dt_hurwitz.Columns.Add("Nombre", typeof(string));
            dt_hurwitz.Columns.Add("Valor", typeof(decimal));
        }
        private void Met_LlenarDatos() {
            Txt_Alternativa.Text = "0,8";
            Txt_Alternativo2.Text = "0,2";
            var table = new DataTable();
            table.Columns.Add("Producto",typeof(string));
            table.Columns.Add("Zona1",typeof(decimal));
            table.Columns.Add("Zona2", typeof(decimal));
            table.Columns.Add("Zona3", typeof(decimal));
            table.Columns.Add("Zona4", typeof(decimal));
            table.Rows.Add(new object[] { "semidescremada", 750, 1050, 1200, 1350 });
            table.Rows.Add(new object[] { "entera", 200, 1250, 1400, 1550 });
            table.Rows.Add(new object[] { "descremada", -75, 975, 1500, 1650 });
            table.Rows.Add(new object[] { "con sabores", -350, 700, 1225, 1750 });
            if (table.Rows.Count>0)
            {
                Datos_Analisis.DataSource = table;
            }
        }
        private void Met_CriterioMaximin(DataGridView _data) {
            Txt_Consola.Text = String.Empty;
            Txt_Consola.Text += "CRITERIO MAXIMIN:" + Environment.NewLine;
            Txt_Consola.Text += "-----------------------------------------" + Environment.NewLine;
            if (_data.Rows.Count > 0)
            {
                for (int i = 0; i < _data.Columns.Count - 1; i++)
                {
                    string impresion = string.Empty;
                    decimal minimo = 0;
                    impresion = _data.Rows[i].Cells[0].Value.ToString();
                    minimo = Met_Minimo(i, _data);
                    Txt_Consola.Text += impresion + "=[" + minimo.ToString() + "]" + Environment.NewLine;
                    dt_Minimos.Rows.Add(new object[] { impresion.Trim(), minimo });
                }
                //validamos cual es el menor de todos
                if (dt_Minimos.Rows.Count > 0)
                {
                    decimal minimo = 100000000;
                    string Nombre = string.Empty;
                    foreach (DataRow row in dt_Minimos.Rows)
                    {
                        try
                        {
                            if (Convert.ToDecimal(row["Valor"].ToString().Trim()) < minimo)
                            {
                                Nombre = row["Nombre"].ToString().Trim();
                                minimo = Convert.ToDecimal(row["Valor"].ToString().Trim());
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hay un dato que no es numerico");
                        }
                    }
                    Txt_Consola.Text += Environment.NewLine + "Criterio pesimista o de Wald (maxi-min):" + Environment.NewLine;
                    Txt_Consola.Text += "-----------------------" + Environment.NewLine;
                    Txt_Consola.Text += "[" + Nombre + "]=[" + minimo + "]";
                    dt_desiciones.Rows.Add(new object[] { Nombre.Trim() });
                    //limpiamos temporales
                    dt_Minimos.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("No hay datos de analisis");
            }           
        }
        private void Met_CriterioMaxiMax(DataGridView _data)
        {
            Txt_Consola.Text = String.Empty;
            Txt_Consola.Text += "CRITERIO MAXIMAX:" + Environment.NewLine;
            Txt_Consola.Text += "-----------------------------------------" + Environment.NewLine;
            if (_data.Rows.Count > 0)
            {
                for (int i = 0; i < _data.Columns.Count - 1; i++)
                {
                    string impresion = string.Empty;
                    decimal maximo = 0;
                    impresion = _data.Rows[i].Cells[0].Value.ToString();
                    maximo = Met_Maximo(i, _data);
                    Txt_Consola.Text += impresion + "=[" + maximo.ToString() + "]" + Environment.NewLine;
                    dt_Maximos.Rows.Add(new object[] { impresion.Trim(), maximo });
                }
                //validamos cual es el mayor de todos
                if (dt_Maximos.Rows.Count>0)
                {
                    decimal maximo = 0;
                    string Nombre = string.Empty;
                    foreach (DataRow row in dt_Maximos.Rows)
                    {
                        try
                        {
                            if (Convert.ToDecimal(row["Valor"].ToString().Trim())>maximo)
                            {
                                Nombre = row["Nombre"].ToString().Trim();
                                maximo = Convert.ToDecimal(row["Valor"].ToString().Trim());
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hay un dato que no es numerico");
                        }
                    }
                    Txt_Consola.Text += Environment.NewLine + "Criterio Optimista (maxi-max'):" + Environment.NewLine;
                    Txt_Consola.Text += "-----------------------" + Environment.NewLine;
                    Txt_Consola.Text += "[" + Nombre + "]=[" + maximo + "]";
                    dt_desiciones.Rows.Add(new object[] { Nombre.Trim() });
                    //limpiamos temporales
                    dt_Maximos.Rows.Clear();
                }

            }
            else
            {
                MessageBox.Show("No hay datos de analisis");
            }
            

        }
        private void Met_CriterioLaplace(DataGridView _data)
        {
            var table = new DataTable();
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Valor", typeof(decimal));
            Txt_Consola.Text = String.Empty;
            Txt_Consola.Text += "El criterio de Laplace o de igual verosimilitud:" + Environment.NewLine;
            Txt_Consola.Text += "-----------------------------------------" + Environment.NewLine;
            if (_data.Rows.Count > 0)
            {
                for (int i = 0; i < _data.Columns.Count - 1; i++)
                {
                    string impresion = string.Empty;
                    decimal Suma = 0;
                    int conteo=0;
                    for (int j = 0; j <= _data.Rows.Count; j++)
                    {

                        // MessageBox.Show(impresion);
                        if (j == 0)
                        {
                            impresion = _data.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                              Suma += Convert.ToDecimal(_data.Rows[i].Cells[j].Value.ToString());
                            conteo++;
                        }


                    }
                    
                    Txt_Consola.Text += impresion + "=[" + Suma.ToString() + "]/["+conteo+"]=["+Suma/conteo+"]" + Environment.NewLine;
                    table.Rows.Add(new object[] { impresion, (Suma / conteo) });
                }
                //validamos cual es el mayor de la media
                decimal media = 0;
                string Nombre = string.Empty;
                foreach (DataRow row in table.Rows)
                {
                    try
                    {
                        if (Convert.ToDecimal(row["Valor"].ToString().Trim())>media)
                        {
                            Nombre = row["Nombre"].ToString().Trim();
                            media = Convert.ToDecimal(row["Valor"].ToString().Trim());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Hay un dato que no es numerico");
                    }
                   
                }
                Txt_Consola.Text += Environment.NewLine + "El criterio de Laplace o de igual verosimilitud:"+ Environment.NewLine ;
                Txt_Consola.Text += "-----------------------"+Environment.NewLine ;
                Txt_Consola.Text += "[" + Nombre + "]=[" + media + "]";
                dt_desiciones.Rows.Add(new object[] { Nombre.Trim() });
            }
            else
            {
                MessageBox.Show("No hay datos de analisis");
            }
            
        }
        private decimal Met_Maximo(int _indice,DataGridView _data) {            
            decimal maximo = 0;            
            for (int j = 0; j <= _data.Rows.Count; j++)
            {                
                if(j>0)
                {
                    try
                    {
                        if (Convert.ToDecimal(_data.Rows[_indice].Cells[j].Value.ToString()) > maximo)
                        {
                            maximo = Convert.ToDecimal(_data.Rows[_indice].Cells[j].Value.ToString());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Un dato de valores no es numerico", "Advertencia");
                    }                  
                }
            }
            return maximo;
        }
        private decimal Met_Minimo(int _indice, DataGridView _data)
        {
            decimal minimo = 1000000000;
            for (int j = 0; j <= _data.Rows.Count; j++)
            {
                if (j > 0)
                {
                    try
                    {
                        if (Convert.ToDecimal(_data.Rows[_indice].Cells[j].Value.ToString()) < minimo)
                        {
                            minimo = Convert.ToDecimal(_data.Rows[_indice].Cells[j].Value.ToString());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Un dato de valores no es numerico", "Advertencia");
                    }
                }
            }
            return minimo;
        }
        private void Met_Hurwitz(DataGridView _data) {
            Txt_Consola.Text = String.Empty;
            Txt_Consola.Text += "Criterio de Hurwicz :" + Environment.NewLine;
            Txt_Consola.Text += "-----------------------------------------" + Environment.NewLine;
            if (_data.Rows.Count > 0)
            {
                for (int i = 0; i < _data.Columns.Count - 1; i++)
                {
                    string impresion = string.Empty;
                    decimal valor = 0;
                    impresion = _data.Rows[i].Cells[0].Value.ToString();
                    try
                    {
                        valor = ((Met_Maximo(i, _data) * Convert.ToDecimal(Txt_Alternativa.Text.Trim()))+(Met_Minimo(i, _data) * Convert.ToDecimal(Txt_Alternativo2.Text.Trim())));
                        Txt_Consola.Text += impresion + "=["+ Met_Maximo(i, _data) + "*"+Convert.ToDecimal(Txt_Alternativa.Text.Trim())+"]" +
                            "+["+ Met_Minimo(i, _data) + "*"+ Convert.ToDecimal(Txt_Alternativo2.Text.Trim()) + "]"+
                            Environment.NewLine;
                        dt_hurwitz.Rows.Add(new object[] { impresion.Trim(), valor });
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Un valor no es numerico");
                    }
                    
                }
                //validamos cual es el mayor de todos
                if (dt_hurwitz.Rows.Count > 0)
                {
                    decimal maximo = 0;
                    string Nombre = string.Empty;
                    foreach (DataRow row in dt_hurwitz.Rows)
                    {
                        try
                        {
                            if (Convert.ToDecimal(row["Valor"].ToString().Trim()) > maximo)
                            {
                                Nombre = row["Nombre"].ToString().Trim();
                                maximo = Convert.ToDecimal(row["Valor"].ToString().Trim());
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hay un dato que no es numerico");
                        }
                    }
                    Txt_Consola.Text += Environment.NewLine + "Criterio de Hurwicz (optimista-pesimista):" + Environment.NewLine;
                    Txt_Consola.Text += "-----------------------" + Environment.NewLine;
                    Txt_Consola.Text += "[" + Nombre + "]=[" + maximo + "]";
                    dt_desiciones.Rows.Add(new object[] { Nombre.Trim() });
                    //limpiamos temporales
                    dt_hurwitz.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("No hay datos de analisis");
            }

        }
        private void Met_Desicion() {
            Txt_Consola.Text = String.Empty;
            Txt_Consola.Text += "Desicion sobre los 4 metodos (CRITERIO DE LAPLACE, OPTIMISTA, PESIMISTA, HURWICZ):" + Environment.NewLine;
            Txt_Consola.Text += "-----------------------------------------" + Environment.NewLine;
            var table = new DataTable();
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Valor", typeof(string));
            if (dt_desiciones.Rows.Count > 0)
            {
                if (dt_desiciones.Rows.Count!=4)
                {
                    MessageBox.Show("Falta algun metodo de los 4 para poder tomar desiciones");
                    return;
                }
                foreach (DataRow row in dt_desiciones.Rows)
                {
                    int conteo = 0;
                    Txt_Consola.Text += row["Nombre"].ToString() + Environment.NewLine;
                    foreach (DataRow row2 in dt_desiciones.Rows)
                    {
                        if (row["Nombre"].ToString().Equals(row2["Nombre"].ToString()))
                        {
                            conteo++;
                        }
                    }
                    table.Rows.Add(new object[] { row["Nombre"].ToString(), conteo });
                }
                if (table.Rows.Count > 0)
                {
                    decimal maximo = 0;
                    string Nombre = string.Empty;
                    foreach (DataRow row in table.Rows)
                    {
                        try
                        {
                            if (Convert.ToDecimal(row["Valor"].ToString().Trim()) > maximo)
                            {
                                Nombre = row["Nombre"].ToString().Trim();
                                maximo = Convert.ToDecimal(row["Valor"].ToString().Trim());
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hay un dato que no es numerico");
                        }
                    }
                    Txt_Consola.Text += Environment.NewLine + "Desicion segun el los resultados de los cuatro criterios:" + Environment.NewLine;
                    Txt_Consola.Text += "-----------------------" + Environment.NewLine;
                    Txt_Consola.Text += "[" + Nombre + "]=[" + maximo + "]";                    
                    //limpiamos temporales
                    dt_desiciones.Rows.Clear();
                }
            }
            else {
                MessageBox.Show("Ejecute los 4 metodos anteriores para las desiciones");
            }
        }
        private void Met_MinimoArrepentimiento(DataGridView _data)
        {
            Txt_Consola.Text = String.Empty;
            Txt_Consola.Text += "Minimo Arrepentimiento :" + Environment.NewLine;
            Txt_Consola.Text += "-----------------------------------------" + Environment.NewLine;
            var dt_min_colum = new DataTable();
            dt_min_colum.Columns.Add("Nombre", typeof(string));
            dt_min_colum.Columns.Add("Valor", typeof(decimal));

            if (_data.Rows.Count > 0)
            {
                for (int i = 1; i <= _data.Rows.Count; i++)
                {
                    decimal minimo = 1000000000;
                    for (int j = 0; j < _data.Columns.Count - 1; j++)
                    {
                        try
                        {
                            if (Convert.ToDecimal(_data.Rows[j].Cells[i].Value.ToString())<minimo)
                            {
                                minimo = Convert.ToDecimal(_data.Rows[j].Cells[i].Value.ToString());
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Algun dato no es numerico");
                        }                       
                    }
                    dt_min_colum.Rows.Add(new object[] { i,minimo});
                }
                if (dt_min_colum.Rows.Count>0)
                {
                    Txt_Consola.Text += "Minimos por columnas" + Environment.NewLine;
                    foreach (DataRow item in dt_min_colum.Rows)
                    {
                        Txt_Consola.Text += "Columna[" + item["Nombre"].ToString() +"]="+ item["Valor"].ToString()+", ";
                    }
                    Txt_Consola.Text += Environment.NewLine;
                    //restamos

                }
            }
            else
            {
                MessageBox.Show("No hay datos para analisar");
            }
        }
    #endregion

    private void Btn_Met1_Click(object sender, EventArgs e)
        {
            Met_CriterioLaplace(Datos_Analisis);
        }

        private void Btn_Met2_Click(object sender, EventArgs e)
        {
            Met_CriterioMaxiMax(Datos_Analisis);
        }

        private void Btn_Met3_Click(object sender, EventArgs e)
        {
            Met_CriterioMaximin(Datos_Analisis);
        }

        private void Btn_Met4_Click(object sender, EventArgs e)
        {
            Met_Hurwitz(Datos_Analisis);
        }

        private void Btn_Met5_Click(object sender, EventArgs e)
        {
            Met_Desicion();
        }

        private void Btn_Met6_Click(object sender, EventArgs e)
        {
            Met_MinimoArrepentimiento(Datos_Analisis);
        }
    }//fin clase
}//fin namespace

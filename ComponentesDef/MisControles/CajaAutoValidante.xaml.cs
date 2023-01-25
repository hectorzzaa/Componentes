using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Componentes.MisControles
{
    /// <summary>
    /// Lógica de interacción para CajaAutoValidante.xaml
    /// </summary>
    public partial class CajaAutoValidante : UserControl
    {

        public String tipoValidacion { get; set; }
        public String errorValidacion { get; set; }

        public CajaAutoValidante()
        {
            InitializeComponent();
        }

        private void MitextoAutoValidante_LostFocus(object sender, RoutedEventArgs e)
        {
            errorValidacion = "No hay error";
            if (tipoValidacion=="DNI")
            {
                chequeoDNI();
            }else if (tipoValidacion == "TFN")
            {
                chequeoTFN();
            }
            else if (tipoValidacion == "CP")
            {
                chequeoCP();
            }
            MiLabelControlError.Content= errorValidacion;
        }

        private void chequeoCP()
        {
            String textoInsertado;
            textoInsertado = MitextoAutoValidante.Text;
            if (textoInsertado.Length == 5)
            {
                try
                {
                    int numeros = Int32.Parse(textoInsertado);
                    errorValidacion = "no hay error";

                }
                catch (FormatException e)
                {
                    errorValidacion = "el CP solo debe tener numeros";
                }
            }
            else
            {
                errorValidacion = "El codigo postal solo debe tener 5 digitos";
            }
        }

        private void chequeoTFN()
        {
            String textoInsertado;
            textoInsertado = MitextoAutoValidante.Text;
            if (textoInsertado.Length == 9)
            {
                try
                {
                    int numeros = Int32.Parse(textoInsertado);
                    errorValidacion = "no hay error";
                    
                }
                catch (FormatException e)
                {
                    errorValidacion = "el telefono solo debe tener numeros";
                }
            }else
            {
                errorValidacion = "El telefono debe tener 9 digitos";
            }
        
        }

        private void chequeoDNI()
        {
            String textoInsertado;
            textoInsertado = MitextoAutoValidante.Text;
            if (textoInsertado.Length == 9)
            {
                try
                {
                    int numeros = Int32.Parse(textoInsertado.Substring(0, 7));
                    try
                    {
                        int letra= Int32.Parse(textoInsertado.Substring(8));
                        errorValidacion = "el ultimo digito debe ser una letra";
                    }catch(FormatException e)
                    {
                        errorValidacion = "No hay errores";
                    }
                }catch(FormatException e)
                {
                    errorValidacion = "Los 8 primeros digitos deben ser números";
                }
            }
            else
            {
                errorValidacion = "El DNI debe tener 9 digitos";
            }
        }

        private void MitextoAutoValidante_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

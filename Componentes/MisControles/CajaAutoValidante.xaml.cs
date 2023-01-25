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
            if (tipoValidacion=="dni")
            {
                chequeoDNI();
            }else if (tipoValidacion == "TFN")
            {
                chequeoTFN();
            }
        }

        private void chequeoTFN()
        {
            throw new NotImplementedException();
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
    }
}

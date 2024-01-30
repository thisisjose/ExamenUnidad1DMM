using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalculadoraIMC_FCN.VIstaModelo
{
    public class VMcalcular : BaseViewModel
    {
        #region VARIABLES
        int _Frecuencia;
        double _Imc;
        string _Mensaje;
        double _Peso;
        double _Altura;

        #endregion
        #region CONSTRUCTOR
        public VMcalcular(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS
        public string Mensaje
        {
            get { return _Mensaje; }
            set { SetValue(ref _Mensaje, value); }
        }
        public double Peso
        {
            get { return _Peso; }
            set { SetValue(ref _Peso, value); }
        }
        public double Altura
        {
            get { return _Altura; }
            set { SetValue(ref _Altura, value); }
        }
        public double Imc
        {
            get { return _Imc; }
            set { SetValue(ref _Imc, value); }
        }

        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void procesoSimple()
        {

        }
        private void CalcularIMC(double p, double a)
        {
            Imc = p / Math.Pow(a, 2);
        }
        public async void BtnCalcularIMC()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Peso)) && !string.IsNullOrEmpty(Convert.ToString(Altura)))
            {

                CalcularIMC(Peso, Altura);

                if (Imc < 18)
                {
                    Mensaje = "Tienes bajo peso";
                }
                else if (Imc >= 18 && Imc <= 24.9)
                {
                    Mensaje = "Peso Normal";
                }
                else if (Imc > 24.9 && Imc <= 29.9)
                {
                    Mensaje = "Tienes Sobre Peso";
                }
                else
                {
                    Mensaje = "Tienes Obesidad";
                }
                await DisplayAlert("Rango de peso", Mensaje, "Quitar");
            }
            else
            {
                await DisplayAlert("Campos vacíos", "Ingrese todos los datos", "Quitar");
            }
        }

        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand BtnImc => new Command(BtnCalcularIMC);
        #endregion
    }
}

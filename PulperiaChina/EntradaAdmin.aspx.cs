using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using CapaNegocio;
using System.IO;

namespace PulperiaChina
{
    public partial class EntradaAdmin : System.Web.UI.Page
    {

        public void CargaInfoEmpresa()
        {
            var neg = new ClassEmpresa();
            var lista = neg.MuestraEmpresa();
            foreach (var item in lista)
            {
                txtempresa.Text = item.Nombre_Empresa;
                txtpropietario.Text = item.Propietario;
                txtadmin.Text = item.Admonistrador;
                txtubicacion.Text = item.Ubicacion;
                txtdesc.Text = item.Descripcion;
                txtmunic.Text = item.Municipio;
                txtdepto.Text = item.Departamento;
                txttelef.Text = item.Telefono;
                txtmail.Text = item.Email;

                if (item.Logo=="")
                {
                    imglogo.ImageUrl="~/Imagenes/logoPC.jpg";
                    Hflogo.Value = "~/Imagenes/logoPC.jpg";
                }
                else
                {
                    imglogo.ImageUrl = item.Logo;
                    Hflogo.Value = item.Logo;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaInfoEmpresa();
            }
        }

        protected void cheditar_CheckedChanged(object sender, EventArgs e)
        {
            if (true)
            {
                txtempresa.Enabled = true;
                txtpropietario.Enabled = true;
                txtadmin.Enabled = true;
                txtubicacion.Enabled = true;
                txtdesc.Enabled = true;
                txtmunic.Enabled = true;
                txtdepto.Enabled = true;
                txttelef.Enabled = true;
                txtmail.Enabled = true;
            }
        }

        public void NuevosDatos()
        {
            var ent = new ClassEntEmpresa();

            //ent.ID_Informacion = Convert.ToInt32(txtid.Text);
            ent.Nombre_Empresa = txtempresa.Text.Trim();
            ent.Propietario = txtpropietario.Text.Trim();
            ent.Admonistrador = txtadmin.Text.Trim();
            ent.Ubicacion = txtubicacion.Text.Trim();
            ent.Descripcion = txtdesc.Text.Trim();
            ent.Municipio = txtmunic.Text.Trim();
            ent.Departamento = txtdepto.Text.Trim();
            ent.Telefono = txttelef.Text.Trim();
            ent.Email = txttelef.Text.Trim();
            subirImagen();
            ent.Logo = Hflogo.Value;
            var neg = new ClassEmpresa();
            if (neg.GuardaEmpresa(ent))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Registros almacenados Correctamente', 'success');", true);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se Pudo Guardar los Registros', 'error');", true);
            }

        }

        #region Sube Imagen
        public string subirImagen()
        {

            bool fileOk = false;
            string respuesta = "";
            string ruta = Server.MapPath("~/Imagenes");
            try
            {
                if (Fulogo.HasFile)//Si tiene archivo seleccionado
                {
                    string extension = Path.GetExtension(Fulogo.FileName).ToLower();
                    string[] extensionValida = { ".jpg", ".png", ".gif", ".jpeg" };
                    for (int i = 0; i < extensionValida.Length; i++)
                    {
                        if (extension == extensionValida[i])
                        {
                            fileOk = true;
                        }
                        if (fileOk)
                        {
                            string nombreImg = Fulogo.FileName.ToString();
                            Fulogo.PostedFile.SaveAs(ruta + nombreImg);
                            Hflogo.Value = "~/Imagenes" + nombreImg;
                            respuesta = "subida";
                        }
                        else
                        {
                            Hflogo.Value = "~/Imagenes/logoPC.jpg";
                            respuesta = "Error";
                        }
                    }
                }
                else
                {
                    Hflogo.Value = "~/Imagenes/logoPC.jpg";
                    respuesta = "Error";
                }
                return respuesta;
            }
            catch (Exception)
            {

                return respuesta;
            }
        }
        #endregion

        public void EditaDatos()
        {
            var ent = new ClassEntEmpresa();

            ent.Nombre_Empresa = txtempresa.Text.Trim();
            ent.Propietario = txtpropietario.Text.Trim();
            ent.Admonistrador = txtadmin.Text.Trim();
            ent.Ubicacion = txtubicacion.Text.Trim();
            ent.Descripcion = txtdesc.Text.Trim();
            ent.Municipio = txtmunic.Text.Trim();
            ent.Departamento = txtdepto.Text.Trim();
            ent.Telefono = txttelef.Text.Trim();
            ent.Email = txttelef.Text.Trim();
            subirImagen();
            ent.Logo = Hflogo.Value;
            var neg = new ClassEmpresa();
            if (neg.ActualizaEmpresa(ent))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Registros almacenados y Actualizados Correctamente', 'success');", true);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo Actualizar los Registros', 'error');", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var neg = new ClassEmpresa();

            if (neg.MuestraEmpresa().Count < 1)
            {
                NuevosDatos();
            }
            else
            {
                EditaDatos();
            }
        }
    }
}
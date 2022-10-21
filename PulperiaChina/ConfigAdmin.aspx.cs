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
    public partial class ConfigAdmin : System.Web.UI.Page
    {
        public void CargaInfoEmpresa()
        {
            var neg = new ClassEmpresa();
            var lista = neg.MuestraEmpresa();
            foreach (var item in lista)
            {
                txtid.Text = item.ID_Informacion.ToString();
                txtempresa.Text = item.Nombre_Empresa;
                txtpropietario.Text = item.Propietario;
                txtadmin.Text = item.Admonistrador;
                txtubicacion.Text = item.Ubicacion;
                txtdesc.Text = item.Descripcion;
                txtmunic.Text = item.Municipio;
                txtdepto.Text = item.Departamento;
                txttelef.Text = item.Telefono;
                txtmail.Text = item.Email;
                txtdolar.Text = item.CambioDolar.ToString();

                if (item.Logo == "")
                {
                    imglogo.ImageUrl = "~/Imagenes/logoPC.jpg";
                    hflogo.Value = "~/Imagenes/logoPC.jpg";
                }
                else
                {
                    imglogo.ImageUrl = item.Logo;
                    hflogo.Value = item.Logo;
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
            ent.Email = txtmail.Text.Trim();
            ent.CambioDolar = int.Parse(txtdolar.Text.Trim());
            subirImagen();
            ent.Logo = hflogo.Value;
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
                if (fulogo.HasFile)//Si tiene archivo seleccionado
                {
                    string extension = Path.GetExtension(fulogo.FileName).ToLower();
                    string[] extensionValida = { ".jpg", ".png", ".gif", ".jpeg" };
                    for (int i = 0; i < extensionValida.Length; i++)
                    {
                        if (extension == extensionValida[i])
                        {
                            fileOk = true;
                        }
                        if (fileOk)
                        {
                            string nombreImg = fulogo.FileName.ToString();
                            fulogo.PostedFile.SaveAs(ruta + nombreImg);
                            hflogo.Value = "~/Imagenes" + nombreImg;
                            respuesta = "subida";
                        }
                        else
                        {
                            hflogo.Value = "~/Imagenes/logoPC.jpg";
                            respuesta = "Error";
                        }
                    }
                }
                else
                {
                    hflogo.Value = "~/Imagenes/logoPC.jpg";
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

            ent.ID_Informacion = Convert.ToInt32(txtid.Text.Trim());
            ent.Nombre_Empresa = txtempresa.Text.Trim();
            ent.Propietario = txtpropietario.Text.Trim();
            ent.Admonistrador = txtadmin.Text.Trim();
            ent.Ubicacion = txtubicacion.Text.Trim();
            ent.Descripcion = txtdesc.Text.Trim();
            ent.Municipio = txtmunic.Text.Trim();
            ent.Departamento = txtdepto.Text.Trim();
            ent.Telefono = txttelef.Text.Trim();
            ent.Email = txtmail.Text.Trim();
            ent.CambioDolar = int.Parse(txtdolar.Text.Trim());
            subirImagen();
            ent.Logo = hflogo.Value;
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

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            var neg = new ClassEmpresa();

            if (neg.MuestraEmpresa().Count < 1)
            {
                NuevosDatos();
                Response.Redirect("/Inicio");
            }
            else
            {
                EditaDatos();
                Response.Redirect("/Inicio");
            }
        }

        protected void chinfo_CheckedChanged(object sender, EventArgs e)
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
                txtdolar.Enabled = true;
            }
        }

        protected void chinfo_CheckedChanged1(object sender, EventArgs e)
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
                txtdolar.Enabled = true;
            }
        }
    }
}
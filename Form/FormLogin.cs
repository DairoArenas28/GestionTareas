using Facturacion.MaterialUI.MaterialSkinUI;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsLoginTask.Context;

namespace WindowsFormsLoginTask
{
    public partial class FormLogin : MaterialForm
    {
        // Instancia de MaterialSkinUI para aplicar el diseño visual utilizando el esquema Material Skin.
        // Este objeto permite manejar el tema, colores y la apariencia de los formularios.
        MaterialSkinUI skinui = new MaterialSkinUI();

        // Almacena el nombre de usuario que el usuario ingresa en el formulario de login.
        String user;

        // Almacena la contraseña que el usuario ingresa en el formulario de login.
        String password;

        // Crea una nueva instancia de la clase Usuario.
        // Esta instancia será utilizada para manejar los datos del usuario, como validaciones y consultas a la base de datos.
        Usuario usuario = new Usuario();

        // Lista que almacenará los objetos de tipo Usuario.
        // Se usa para guardar los usuarios obtenidos de la base de datos (por ejemplo, los que coinciden con el nombre y la contraseña).
        List<Usuario> usuarioList = new List<Usuario>();


        bool bResult;
        
        // Constructor del formulario
        public FormLogin()
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
            skinui.MaterialSkin(this); // Aplica el estilo de Material Skin al formulario.

        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Login", valida las credenciales del usuario
        /// y abre el formulario principal si las credenciales son correctas.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Obtiene el nombre de usuario desde el campo de texto "textUsuario".
            user = textUsuario.Text;

            // Obtiene la contraseña desde el campo de texto "textPassword".
            password = textPassword.Text;

            // Llama al método de validación del usuario para comprobar si las credenciales son correctas.
            bResult = usuario.UsuarioValidacion(user, password);

            // Obtiene la lista de usuarios basándose en las credenciales introducidas.
            usuarioList = usuario.ObtenerUsuario(user, password);

            // Verifica si las credenciales del usuario son válidas.
            if (bResult)
            {
                // Si las credenciales son correctas, crea una nueva instancia del formulario principal (FormMain),
                // pasando la lista de usuarios como parámetro.
                FormMain formMain = new FormMain(usuarioList);

                // Establece el formulario de inicio de sesión (this) como propietario del formulario principal.
                formMain.Owner = this;

                // Configura la posición del formulario principal para que se muestre centrado en la pantalla.
                formMain.StartPosition = FormStartPosition.CenterScreen;

                // Oculta el formulario de inicio de sesión.
                this.Hide();

                // Muestra el formulario principal.
                formMain.Show();
            }
            else
            {
                // Si las credenciales no son correctas, muestra un mensaje de error al usuario.
                MessageBox.Show("Usuario y/o contraseña incorrectos");
            }
        }

    }
}

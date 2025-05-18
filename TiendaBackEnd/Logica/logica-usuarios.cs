using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Datos;

namespace Logica
{
    public class logica_usuarios
    {
        datosUsuario op = new datosUsuario();
        datosCliente op2 = new datosCliente();


        public List<USUARIO> SeleccionarUsuarios()
        {
            return op.SeleccionarUsuarios();
        }

        public USUARIO seleccionarUsuarioPorUsuario(string usuario)
        {
            return SeleccionarUsuarios().Where(usu => usu.US_USUARIO.Contains(usuario)).SingleOrDefault();
        }

        //#region metodos de accion 

        public int insertarUsuario(USUARIO usuInsertado)
        {
            return op.insertarUsuario(usuInsertado);
        }

        public bool actualizarUsuario(USUARIO usuActualizado)
        {
            return op.actualizarUsuario(usuActualizado);
        }

        public bool eliminarUsuario(int id)
        {
            return op.eliminarUsuario(id);
        }

        //# endregion

        public bool registrarUsuarioCliente(
            string CLI_CEDULA,
            int US_COD,
            string CLI_NOMBRE,
            string CLI_TELEFONO,
            string CLI_CORREO,
            string CLI_DIRECCION,
            string CLI_ESTADO,
            string US_USUARIO,
            string US_PASS,
            string US_ROL)
        {
            try
            {
                USUARIO usu = new USUARIO();
                usu.US_COD = US_COD;
                usu.US_USUARIO = US_USUARIO;
                usu.US_PASS = US_PASS;
                usu.US_ROL = US_ROL;
                CLIENTE cli = new CLIENTE();
                cli.CLI_CEDULA = CLI_CEDULA;
                cli.US_COD = US_COD;
                cli.CLI_NOMBRE = CLI_NOMBRE;
                cli.CLI_TELEFONO = CLI_TELEFONO;
                cli.CLI_CORREO = CLI_CORREO;
                cli.CLI_DIRECCION = CLI_DIRECCION;
                cli.CLI_ESTADO = CLI_ESTADO;

                if (op.insertarUsuario(usu) > 0 && op2.insertarCliente(cli) != "")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public USUARIO autenticarUsuario(string US_USUARIO, string US_PASS)
        {
            return op.autenticarUsuario(US_USUARIO, US_PASS);
        }
    }
}
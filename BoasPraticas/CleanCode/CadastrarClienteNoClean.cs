using System;
using BoasPraticas.Domain.Constants;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace BoasPraticas.CleanCode
{
    public class CadastrarClienteNoClean
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public void Cadastrar(string nome, string cpf, string email)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException(nome, MessagesConsts.MSG_NOTEMPTY);

            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentNullException(cpf, MessagesConsts.MSG_NOTEMPTY);

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(email, MessagesConsts.MSG_NOTEMPTY);

            Nome = nome;
            CPF = cpf;
            Email = email;

            using var conn = new SqlConnection("minhaconexao");
            using var command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO CLIENTE (Nome, CPF, Email) VALUES (@Nome, @CPF, @Email)";
            command.Parameters.AddWithValue("Nome", Nome);
            command.Parameters.AddWithValue("CPF", CPF);
            command.Parameters.AddWithValue("Email", Email);

            command.ExecuteNonQuery();

            //cria uma mensagem
            var mensagemEmail = new MailMessage("cadastro@cadastro.com.br", Email, "Cadastro do sistema", "Cadastro realizado com sucesso.");

            SmtpClient client = new SmtpClient("smtp.dominio.com", 587);
            {
                client.EnableSsl = true;
            };

            var cred = new NetworkCredential("SEU_EMAIL@gmail.com", "SUA_SENHA");
            client.Credentials = cred;

            // inclui as credenciais
            client.UseDefaultCredentials = true;

            // envia a mensagem
            client.Send(mensagemEmail);
            
        }
    }
}

using System;

namespace BoasPraticas.Domain.Entities
{
    public class Cliente
    {
        protected Cliente(int id, string nome, string sobreNome, string CPF, string email)
        {
            SetId(id);
            SetNome(nome);
            SetSobreNome(sobreNome);
            SetCPF(CPF);
            SetEmail(new Email(email));
        }

        public Cliente(string nome, string sobreNome, string CPF, Email email)
        {
            SetNome(nome);
            SetSobreNome(sobreNome);
            SetCPF(CPF);
            SetEmail(email);
        }
        public int Id { get; private set; } = new Random().Next();

        public string Nome { get; private set; }

        public string SobreNome { get; private set; }

        public string CPF { get; private set; }

        public Email Email { get; private set; }

        public void SetId(int id)
        {
            if (id > 0)
                Id = id;
        }

        public void SetNome(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
                Nome = nome;
        }

        public void SetSobreNome(string sobreNome)
        {
            if (!string.IsNullOrEmpty(sobreNome))
                SobreNome = sobreNome;
        }

        public void SetCPF(string cpf)
        {
            if (!string.IsNullOrEmpty(cpf) && cpf.Length == 11)
                CPF = cpf;
        }

        public void SetEmail(Email email)
        {
            if (email != null)
                Email = email;
        }
    }
}

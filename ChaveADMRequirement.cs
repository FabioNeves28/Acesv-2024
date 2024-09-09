using Microsoft.Data.SqlClient;

public class ChaveADMRequirement
{
    // Defina um valor padrão que não seja 0

    public string Chama_ChaveADM(string userEmail)
    {

        using (var connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=Dados;Integrated Security=True;"))
        {
            connection.Open();

            string chaveADM = null;

            // Consulta SQL para obter a Chave_ADM com base no CPF do usuário logado
            var queryChaveADM = "SELECT Chave_ADM FROM AspNetUsers WHERE Cpf = (SELECT Cpf FROM AspNetUsers WHERE UserName = @UserEmail)";
            using (var commandChaveADM = new SqlCommand(queryChaveADM, connection))
            {
                commandChaveADM.Parameters.AddWithValue("@UserEmail", userEmail); // Certifique-se de ter a variável userEmail definida

                var chaveADMResult = commandChaveADM.ExecuteScalar();

                // Verifique se o valor não é DBNull.Value antes de usá-lo
                if (chaveADMResult != null && chaveADMResult != DBNull.Value)
                {
                    // Converta o valor para int
                    chaveADM = chaveADMResult.ToString(); // Se Chave_ADM for int, converta para string se necessário
                }
                // Se chaveADMResult for null ou DBNull.Value, a variável chaveADM permanecerá com o valor padrão
            }

            // Agora você tem a chaveADM disponível para uso
            return chaveADM;
        }

        // Agora você tem a chaveADM disponível para uso
    }
}

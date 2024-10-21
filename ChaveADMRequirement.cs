using Microsoft.Data.SqlClient;

public class ChaveADMRequirement
{

    public string Chama_ChaveADM(string userEmail)
    {
        var dataSourceID = Environment.MachineName;

        using (var connection = new SqlConnection($"Data Source={Environment.MachineName}; Initial Catalog=Dados;Integrated Security=True;"))
        {
            connection.Open();

            string chaveADM = null;

            var queryChaveADM = "SELECT Chave_ADM FROM AspNetUsers WHERE Cpf = (SELECT Cpf FROM AspNetUsers WHERE UserName = @UserEmail)";
            using (var commandChaveADM = new SqlCommand(queryChaveADM, connection))
            { 
                commandChaveADM.Parameters.AddWithValue("@UserEmail", userEmail);

                var chaveADMResult = commandChaveADM.ExecuteScalar();


                if (chaveADMResult != null && chaveADMResult != DBNull.Value)
                {
                    chaveADM = chaveADMResult.ToString();
                }
            }

            return chaveADM;
        }

    }
}

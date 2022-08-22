namespace DAL
{
    public static class Conexao
    {
        public static string StringDeConexao 
        {
            get
            {
                return @"User ID=sa;Initial Catalog=CONTROLEVEICULAR;Data Source=.\SQLEXPRESS2019;Password=Senailab05";//computador senai
            }
        }
    }
}

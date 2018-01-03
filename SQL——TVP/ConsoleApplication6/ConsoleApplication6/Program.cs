using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class Product
    {
        public int ID;
        public string Name;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Sql相关语句保存在 SQL——Procedure类中
            //TestGetProductsByIDs();//查询
            //TestDeleteProductsByIDs();//删除
            //TestInsertProducts();//增加
            //TestUpdateProducts();//更新
        }
        public static void TestDeleteProductsByIDs()
        {
            Collection<int> productIDs = new Collection<int>();
            productIDs.Add(1);
            productIDs.Add(2);
            using (SqlConnection conn = new SqlConnection("Server=.;Database=TSQLFundamentals2008;User ID=sa;Password=syspro;"))
            {
                DeleteProductsByIDs(conn, productIDs);
            }

        }
        public static void TestGetProductsByIDs()
        {
            Collection<int> productIDs = new Collection<int>();
            Console.WriteLine();
            Console.WriteLine("----- Get Product ------");
            Console.WriteLine("Product IDs: 1,2,3,4,5");
            productIDs.Add(1);
            productIDs.Add(2);
            //productIDs.Add(3);
            productIDs.Add(4);
            productIDs.Add(5);
            using (SqlConnection conn = new SqlConnection("Server=.;Database=TSQLFundamentals2008;User ID=sa;Password=syspro;"))
            {
                Collection<Product> dtProducts = GetProductsByIDs(conn, productIDs);
                foreach (Product product in dtProducts)
                {
                    Console.WriteLine("{0}   {1}", product.ID, product.Name);
                }
            }



        }
        public static void TestInsertProducts()
        {
            Collection<Product> ProductsID = new Collection<Product>();
            ProductsID.Add(
            new Product() { ID = 5, Name = "水水水" }
                                 );
            ProductsID.Add(new Product() {ID =6,Name="火火火" });
            using (SqlConnection conn =new SqlConnection ("Server=.;Database=TSQLFundamentals2008;User ID=sa;Password=syspro;"))
            {
                InsertProducts(conn,ProductsID);
            }
        }
        public static void TestUpdateProducts()
        {
            Collection<Product> ProductsIDs = new Collection<Product>();
            ProductsIDs.Add(new Product() { ID=2,Name="222"});
            ProductsIDs.Add(new Product() { ID=3,Name="333"});
            using (SqlConnection conn=new SqlConnection ("Server=.;Database=TSQLFundamentals2008;User ID=sa;Password=syspro"))
            {
                UpdateProducts(conn,ProductsIDs);
            }
        }
        /// <summary>
        /// Data access layer. Gets products by the collection of the specific product' ID.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="productIDs"></param>
        /// <returns></returns>
        public static Collection<Product> GetProductsByIDs(SqlConnection conn, Collection<int> productIDs)
        {
            conn.Open();
            Collection<Product> products = new Collection<Product>();
            DataTable dtProductIDs = new DataTable("Product");
            dtProductIDs.Columns.Add("ID", typeof(int));

            foreach (int id in productIDs)
            {
                dtProductIDs.Rows.Add(
                    id
                );
            }

            //SqlParameter tvpProduct = new SqlParameter("@ProductIDsTVP", dtProductIDs);
            //tvpProduct.SqlDbType = SqlDbType.Structured;
            //SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "procGetProducts", tvpProduct);

            SqlCommand sqlcom = new SqlCommand("dbo.procGetProductsByProductIDsTVP", conn);
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.Add("@ProductIDsTVP", dtProductIDs);
            //sqlcom.Parameters.Add(tvpProduct);
            using (SqlDataReader dataReader = sqlcom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.ID = dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0);
                    product.Name = dataReader.IsDBNull(1) ? (string)null : dataReader.GetString(1).Trim();

                    products.Add(product);
                }
            }
            return products;
        }
        public static void DeleteProductsByIDs(SqlConnection conn, Collection<int> productIDs)
        {
            conn.Open();
            DataTable dtProductIDs = new DataTable();
            dtProductIDs.Columns.Add("ID", typeof(int));
            foreach (int item in productIDs)
            {
                dtProductIDs.Rows.Add(item);
            }
            using (SqlCommand sqlcmd = new SqlCommand("procDeleteProductsByProductIDsTVP", conn))
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@ProductIDsTVP", dtProductIDs);
                sqlcmd.ExecuteNonQuery();
            }
        }
        public static void InsertProducts(SqlConnection conn,Collection<Product>productIDs)
        {
            conn.Open();
            DataTable dtProductIDs=new DataTable ();
            dtProductIDs.Columns.Add("ID",typeof(int));
            dtProductIDs.Columns.Add("Name",typeof(string));
            foreach (Product  product in productIDs)
            {
                dtProductIDs.Rows.Add(product.ID,product.Name);
            }
            SqlCommand sqlcom = new SqlCommand("procInsertProductsByProductTVP",conn);
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.Add("@ProductIDsTVP", dtProductIDs);
            sqlcom.ExecuteNonQuery();
        }
        public static void UpdateProducts(SqlConnection conn,Collection<Product>productIDs)
        {
            conn.Open();
            DataTable dtProductIDs = new DataTable();
            dtProductIDs.Columns.Add("ID",typeof(int));
            dtProductIDs.Columns.Add("Name",typeof(string));
            foreach (Product item in productIDs)
            {
                dtProductIDs.Rows.Add(item.ID,item.Name);
            }
            SqlCommand sqlcom = new SqlCommand("procUpdateProductsByProductTVP", conn);
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.Add("@ProductTVP", dtProductIDs);
            sqlcom.ExecuteNonQuery();
        }
    }
}

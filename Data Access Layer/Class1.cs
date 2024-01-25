using System;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class Class1
    {
        public static int i = 0;
        public static string s = " ";
        public static string stepDetails = " ";
        public static int numberOfStep;
        public static int[] stepTime;
        public static string[] stepDetail;

        public static string connectionString = "Data Source=DESKTOP-6K06NP6\\SQLEXPRESS;Initial Catalog=Coock_Ease;Integrated Security=True;";

        public static void Coocking_Step_Data_View(string recipeID)
        {
            stepDetails = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string stepNumQuery = "SELECT CS_STEP_NUM FROM CE_COOCKING_STEP WHERE REC_ID = @User_ID";
                string stepDetailsQuery = "SELECT [CS_STEP-{0}_DETAILS] FROM CE_COOCKING_STEP WHERE REC_ID = @User_ID";
                string stepTimeQuery = "SELECT [CS_STEP-{0}_TIME] FROM CE_COOCKING_STEP WHERE REC_ID = @User_ID";

                using (SqlCommand stepNumCommand = new SqlCommand(stepNumQuery, connection))
                {
                    stepNumCommand.Parameters.AddWithValue("@User_ID", recipeID);
                    using (SqlDataReader stepNumReader = stepNumCommand.ExecuteReader())
                    {
                        if (stepNumReader.Read())
                        {
                            numberOfStep = Convert.ToInt32(stepNumReader["CS_STEP_NUM"] == DBNull.Value ? "0" : stepNumReader["CS_STEP_NUM"].ToString());
                            stepTime = new int[numberOfStep];
                            stepDetail = new string[numberOfStep];
                        }
                    }
                }

                for (int stepIndex = 1; stepIndex <= numberOfStep; stepIndex++)
                {

                    using (SqlCommand stepDetailsCommand = new SqlCommand(string.Format(stepDetailsQuery, stepIndex), connection))
                    {
                        stepDetailsCommand.Parameters.AddWithValue("@User_ID", recipeID);
                        using (SqlDataReader stepDetailsReader = stepDetailsCommand.ExecuteReader())
                        {
                            if (stepDetailsReader.Read())
                            {
                                s = stepDetailsReader[string.Format("CS_STEP-{0}_DETAILS", stepIndex)] == DBNull.Value ? "" : stepDetailsReader[string.Format("CS_STEP-{0}_DETAILS", stepIndex)].ToString();
                                if (s != "NULL")
                                {
                                    //tepDetail[stepIndex] = s;
                                    stepDetail[i] = s + "\n";
                                    if (stepIndex <= numberOfStep)
                                    {
                                        s = " ";
                                    }
                                }
                            }
                        }
                    }

                    using (SqlCommand stepTimeCommand = new SqlCommand(string.Format(stepTimeQuery, stepIndex), connection))
                    {
                        stepTimeCommand.Parameters.AddWithValue("@User_ID", recipeID);
                        using (SqlDataReader stepTimeReader = stepTimeCommand.ExecuteReader())
                        {
                            if (stepTimeReader.Read())
                            {
                                if (stepTimeReader[string.Format("CS_STEP-{0}_TIME", stepIndex)] != DBNull.Value)
                                {
                                    int x = Convert.ToInt32(stepTimeReader[string.Format("CS_STEP-{0}_TIME", stepIndex)]);
                                    if (i < numberOfStep)
                                    {
                                        stepTime[i] = x;

                                        i++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Index out of bounds. Array is not large enough for the number of steps.");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

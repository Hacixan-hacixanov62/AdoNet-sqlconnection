
using AdoNetExample.Data;
using AdoNetExample.Models;
using Microsoft.Data.SqlClient;
using System.Threading.Channels;

AppDbContext context = new ();  

void GetAllStudents()
{
    context.CheckConnection();

    using (SqlCommand command = new SqlCommand("SELECT * FROM Students", context.connection))
    {
        using (SqlDataReader reader = command.ExecuteReader())
        {
            List<Student> students = new();


            while (reader.Read())
            {
                students.Add(new Student()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    FullName = reader["FullName"].ToString(),
                    Age = Convert.ToInt32(reader["Age"]),
                    Email = reader["Email"].ToString()
                });

            }

            reader.Close();
            context.connection.Close();

            foreach (var item in students)
            {
                string data = $"Id - {item.Id}, FullName - {item.FullName},Age - {item.Age}, Email - {item.Email}";
                Console.WriteLine(data);
            }
        }

       
    }
       

}

void CreateStudent(Student student)
{
    context.CheckConnection();

    using (SqlCommand command = new SqlCommand("INSERT INTO Students (FullNAme,Age,Email) VALUES (@fulName,@age,@email)", context.connection))
    {
       
        
            command.Parameters.AddWithValue("@filName", student.FullName);
            command.Parameters.AddWithValue("@age", student.Age);
            command.Parameters.AddWithValue("@email", student.Email);


            int rawAffect = command.ExecuteNonQuery();

            if (rawAffect > 0)
            {
                Console.WriteLine("Data successfully added");

            }

            context.connection.Close();
        
         
    }


}

Console.WriteLine("Add student full name: ");
string fullname = Console.ReadLine();

Console.WriteLine("Add student age: ");
int stuAge = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Add student email: ");
string email = Console.ReadLine();

CreateStudent(new Student
{
    FullName = fullname,
    Age = stuAge,
    Email = email

});


GetAllStudents();
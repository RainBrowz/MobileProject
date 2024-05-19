using SQLite;

namespace MobileProject
{
    public static class UtilityClass
    {
        public static async Task DeleteStudentAsync(SQLiteAsyncConnection db, int Id, string CouId)
        {
            // Delete the courses
            await db.ExecuteAsync("DELETE Courses WHERE CourseId =", CouId);

            // Delete the student
            await db.ExecuteAsync("DELETE Students WHERE Id =", Id);
        }
    }
}


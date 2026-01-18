using Microsoft.AspNetCore.Mvc;
using TheSampleApi.Data;

namespace TheSampleApi.Endpoints;

public static class CourseEndpoint 
{
    public static void AddCourseEndpoints(this WebApplication app)
    {
        app.MapGet("/courses", LoadAllCourses);
        app.MapGet("/courses/{id}", LoadCourseById);
    }

    private static IResult LoadAllCourses(CourseData data, string? courseType, string? search)
    {
        var output = data.Courses;

        //filtering by course type
        if(string.IsNullOrEmpty(courseType) == false)
        {
            output.RemoveAll(course => string.Compare(
                course.CourseType, 
                courseType, 
                StringComparison.OrdinalIgnoreCase) != 0);
        }

        //filtering by search
        if(string.IsNullOrEmpty(search) == false)
        {
            output.RemoveAll(course => 
                !course.CourseName.Contains(search, StringComparison.OrdinalIgnoreCase) &&
                !course.ShortDescription.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        return Results.Ok(output);
    }

    private static IResult LoadCourseById(CourseData data, int id)
    {
        var output = data.Courses.SingleOrDefault(course => course.Id == id);

        if (output is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(output);
    }
}
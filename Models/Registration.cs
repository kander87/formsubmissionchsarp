#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FormSubmission.Models;


public class Registration
{

    [Required(ErrorMessage = "Name is required")]
    [MinLength(2, ErrorMessage ="Name must be at least 2 characters long")]
    public string Name {get;set;}

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")] 
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Invalid pattern.")]   
    public string Email {get;set;}

    [FutureDate]
    public DateTime Date {get;set;}
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage ="Password must be at least 8 characters.")]
    public string Password {get;set;}

    [Required(ErrorMessage = "Favorite Odd Number is required")]
    [OddNumber]
    public int FavoriteOddNumber {get;set;}

    // [MinLength(20, ErrorMessage ="Please write a 20 word essay or nothing at all. Thank you. Goodbye.")]
    // public string? Comment {get;set;} 
}


public class FutureDateAttribute : ValidationAttribute
{        

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {        
    if ((DateTime)value > DateTime.Now){
    
        return new ValidationResult("You must choose a date from the past!");
    } else {
        return ValidationResult.Success;
    }}
}

public class OddNumberAttribute : ValidationAttribute
{        
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {        
    if (((int)value %2) != 1){
    
        return new ValidationResult("You must choose an odd number!");
    } else {
        return ValidationResult.Success;
    }}
}



// public class PasswordAttribute : ValidationAttribute
// {        

//     protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
//     {        
//     if ((string)MinLengthAttribute) < 8){
    
//         return new ValidationResult("You must choose a date from the past!");
//     } else {
//         return ValidationResult.Success;
//     }}
// }


// public class EmailAttribute : ValidationAttribute
// {        private static bool IsValid(string email)
//         { 
//             string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

//             return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
//         }}


        // Regex validateGuidRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
        // Console.WriteLine(validateGuidRegex.IsMatch("-Secr3t."));  // prints True
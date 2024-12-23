namespace Domain.Shared.Constants;

/// <summary>
/// Contains constants that allow you to set validation rules for the domain model
/// </summary>
public static class Validation
{
    public const string REGULAR_SPECIFIC_CHARACTERS_PATTERN = @"[!.,?*&^%$#@]";
    public const string REGULAR_EMAIL_PATTERN = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";

    public const string REGULAR_PASSWORD_UPPERCASE_PATTERN = @"[A-Z]";
    public const string REGULAR_PASSWORD_LOWERCASE_PATTERN = @"[a-z]";
    public const string REGULAR_PASSWORD_DIGIT_PATTERN = @"[0-9]";
    public const string REGULAR_PASSWORD_SPECIAL_HARACTER_PATTERN = @"[\W_]";

    public const int MIN_HASHED_PASSWORD_LENGHT = 60;
    public const string EXPECTED_HASHED_PASSWORD_PREFIX = "$2x";
    
    public const int MIN_USERNAME_LENGHT = 2;
    public const int MAX_USERNAME_LENGHT = 20;

    public const int MIN_PASSWORD_LENGHT = 12;
    public const int MAX_PASSWORD_LENGHT = 100;
    
    
    public const int MIN_SURNAME_LENGHT = 5;
    public const int MAX_SURNAME_LENGHT = 30;
    
    public const int MIN_HALL_NAME_LENGHT = 3;
    public const int MAX_HALL_NAME_LENGHT = 40;
    
    public const int MIN_SERVICE_NAME_LENGHT = 5;
    public const int MAX_SERVICE_NAME_LENGHT = 30;

    public static DateOnly DATE_NOW = new DateOnly(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
}
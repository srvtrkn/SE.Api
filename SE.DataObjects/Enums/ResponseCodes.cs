namespace SE.DataObjects
{
    public enum ResponseCodes
    {
        Successful = 0,
        SystemError = 1,
        DbError = 2,
        NoPermissionFound = 3,
        NoRecordFound = 4,
        WorkflowError = 5,
        ServiceError = 6,
        IncorrectLoginCredentials = 8,
        EmailAddressDefinedAlready = 9,
        Authorized = 10,
        NotAuthorized = 11,
        AlreadyDefined = 12,
        MissingData = 13,
        ActivationError = 14,
        UserLockedOut = 15,
        OtherMachineLogin = 16,
        Limited = 17,
        InsertNotCompleted = 18,
        UpdateNotCompleted = 19,
        DeleteNotCompleted = 20,
        ParameterValidationError = 21,
        ValidationServiceAuthenticationError = 22,
        InvalidOrder = 23,
        SubmitOrderInsertFailed = 24,
        IdCouldntReceive = 25,
        FileNotFound = 26,
        FileProblem = 27
    }
}

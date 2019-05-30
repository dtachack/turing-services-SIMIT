namespace UtilitiesLibrary
{
    public static class Strings
    {
        public static string RepositoryNotInitialized(string repositoryName)
        {
            return $"El respositorio {repositoryName} no se encuentra inicializado.";
        }

        public static string ValidateNotNulOrEmptyException(string name, string typeName, string invokerName, int lineNumber)
        {
            return $"El objeto {name} de tipo ({typeName}) se encuentra NULO o VACÍO. Método ({invokerName}). Linea #{lineNumber}";
        }

        public static string ValidateNotNullException(string name, string typeName, string invokerName, int lineNumber)
        {
            return $"El objeto {name} de tipo ({typeName}) se encuentra NULO o VACÍO. Método ({invokerName}). Linea #{lineNumber}";
        }

        
    }
}

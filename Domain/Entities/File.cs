namespace Domain.Entities
{
    /// <summary>
    /// Class <c>File</c> represents a file physically stored in a disk drive. 
    /// </summary>
    public class File : BaseEntity<long>
    {
        /// <summary>
        /// The name of a file comprises the file name and the extension.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The path is the relative path to the root of the selected file server, not including the file name.
        /// <para>
        /// The relative path is used so that the path would be consistent and unaffected by the file server 
        /// used for different environment.
        /// </para>
        /// </summary>
        public string  Path { get; set; }
    }
}

namespace GraphEditor
{
    class CreateProductOpenFile: Creator_File
    {
        public override Product_File FactoryMethod() { return new OpenFile(); }
    }
}

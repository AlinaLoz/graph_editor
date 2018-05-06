namespace GraphEditor
{
    class CreateProductSaveFile: Creator_File
    {
        public override Product_File FactoryMethod() { return new SaveFile(); }
    }
}

namespace html2md_yml;

class ConversionCondition
{
	public TargetType In;
	public string Out;

	public ConversionCondition(){
		In = new TargetType();
		Out = "";
	}
}


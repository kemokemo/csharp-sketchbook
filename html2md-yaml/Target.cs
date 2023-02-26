using HtmlAgilityPack;

namespace html2md_yml;

class TargetType {
  public string Name;
  public string? Class;

  public TargetType() {
    Name = "";
    Class = null;
  }
}

class TargetTypeChecker {
  public static bool IsTarget(TargetType tt, HtmlNode node){
      if(tt.Name != node.Name){
        return false;
      }

      if(tt.Class != null && !node.GetClasses().Contains(tt.Class)){
        return false;
      }

      return true;
  }
}

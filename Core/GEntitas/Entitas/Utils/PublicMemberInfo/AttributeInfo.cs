using System.Collections.Generic;

namespace GEntitas.Utils {

    public class AttributeInfo {

        public readonly object attribute;
        public readonly List<PublicMemberInfo> memberInfos;

        public AttributeInfo(object attribute, List<PublicMemberInfo> memberInfos) {
            this.attribute = attribute;
            this.memberInfos = memberInfos;
        }
    }
}

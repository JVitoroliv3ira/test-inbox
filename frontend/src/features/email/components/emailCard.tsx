import { Card } from "@/components/ui/card";
import { Badge } from "@/components/ui/badge";
import { EmailListItem } from "@/types/output/email";

interface EmailCardProp {
  email: EmailListItem;
  onClick: () => void;
}

export function EmailCard({ email, onClick }: EmailCardProp) {
  return (
    <Card
      onClick={onClick}
      className="cursor-pointer hover:bg-accent transition-colors p-3 gap-0 space-y-2"
    >
      <div className="w-full">
        <span className="text-base font-medium">
          {email.subject ?? "E-mail sem assunto"}
        </span>
      </div>

      <div className="w-full flex flex-wrap gap-2 items-center">
        <span className="text-sm text-muted-foreground">De:</span>
        {email.from ? (
          <Badge variant="outline">{email.from}</Badge>
        ) : (
          <span className="text-sm text-muted-foreground italic">
            Remetente não informado
          </span>
        )}
      </div>

      <div className="w-full flex flex-wrap gap-2 items-center">
        <span className="text-sm text-muted-foreground">Para:</span>
        {email.to && email.to.length > 0 ? (
          email.to.map((address, idx) => (
            <Badge key={idx} variant="outline">
              {address}
            </Badge>
          ))
        ) : (
          <span className="text-sm text-muted-foreground italic">
            Destinatários não informados
          </span>
        )}
      </div>
    </Card>
  );
}

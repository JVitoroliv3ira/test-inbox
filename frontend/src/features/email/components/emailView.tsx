import {
    Card,
    CardContent,
    CardDescription,
    CardHeader,
    CardTitle,
  } from "@/components/ui/card";
  import { Button } from "@/components/ui/button";
  import { Trash } from "lucide-react";
  import { EmailDetails } from "@/types/output/email";
  
  interface EmailViewProps {
    email: EmailDetails;
    onDelete?: () => void;
  }
  
  export function EmailView({ email, onDelete }: EmailViewProps) {
    return (
      <Card className="w-full h-full mx-auto border-none shadow-none p-0 gap-0 space-y-3">
        {onDelete && (
          <div className="flex items-center justify-end p-3 border-b-2 border-muted">
            <Button
              variant="ghost"
              size="icon"
              className="text-muted-foreground hover:text-destructive"
              onClick={onDelete}
            >
              <Trash className="w-4 h-4" />
            </Button>
          </div>
        )}
  
        <CardHeader className="border-b-2 border-muted p-0 pb-3">
          <CardTitle className="text-lg font-semibold">
            {email.subject || "Sem assunto"}
          </CardTitle>
          <CardDescription>
            De:{" "}
            <span className="font-medium">{email.from || "Desconhecido"}</span>
          </CardDescription>
          {email.to && email.to.length > 0 && (
            <CardDescription>
              Para:{" "}
              <span className="text-muted-foreground">
                {email.to.join(", ")}
              </span>
            </CardDescription>
          )}
        </CardHeader>
  
        <CardContent>
          <div className="whitespace-pre-line text-sm text-muted-foreground">
            {email.body || "Sem conteúdo"}
          </div>
        </CardContent>
      </Card>
    );
  }
  
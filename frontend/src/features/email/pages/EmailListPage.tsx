import { Layout } from "@/components/layout";
import { EmailList } from "../components/emailList";
import { getEmailDetails } from "@/lib/email";
import { useState } from "react";
import { EmailDetails } from "@/types/output/email";
import { EmailView } from "../components/emailView";
import { EmailViewSkeleton } from "../components/emailViewSkeleton";

export function EmailListPage() {
  const [details, setDetails] = useState<EmailDetails | undefined>(undefined);
  const [loadingDetails, setLoadingDetails] = useState(false);

  const loadEmailDetails = async (id: number) => {
    setLoadingDetails(true);
    setDetails(undefined);
    try {
      const res = await getEmailDetails(id);
      setDetails(res);
    } catch (err) {
      console.error("Erro ao carregar detalhes do e-mail", err);
    } finally {
      setLoadingDetails(false);
    }
  };

  return (
    <Layout>
      <div className="w-full h-[calc(100vh-170px)] grid grid-cols-1 md:grid-cols-5">
        <div className="col-span-1 md:col-span-3 p-3 overflow-y-auto">
          <EmailList onCardClick={loadEmailDetails} />
        </div>
        <div className="col-span-1 md:col-span-2 p-3 overflow-y-auto">
          {loadingDetails ? (
            <EmailViewSkeleton />
          ) : details ? (
            <EmailView email={details} onDelete={() => {}} />
          ) : (
            <div className="flex items-center justify-center text-sm text-muted-foreground p-3">
              Selecione um e-mail para visualizar.
            </div>
          )}
        </div>
      </div>
    </Layout>
  );
}

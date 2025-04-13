import { Layout } from "@/components/layout";
import { EmailList } from "../components/emailList";
import { getEmailDetails } from "@/lib/email";
import { useState } from "react";
import { EmailDetails } from "@/types/output/email";
import { EmailView } from "../components/emailView";

export function EmailListPage() {
  const [details, setDetails] = useState<EmailDetails | undefined>(undefined);

  const loadEmailDetails = async (id: number) => {
    const res = await getEmailDetails(id);
    setDetails(res);
  }

  return (
    <Layout>
      <div className="w-full h-[calc(100vh-170px)] grid grid-cols-1 md:grid-cols-5">
        <div className="col-span-1 md:col-span-3 p-3 overflow-y-auto">
          <EmailList onCardClick={loadEmailDetails}/>
        </div>
        <div className="col-span-1 md:col-span-2 p-3">
          {details && <EmailView email={details} onDelete={() => {}} />}
        </div>
      </div>
    </Layout>
  );
}

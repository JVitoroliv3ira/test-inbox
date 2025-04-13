import { Layout } from "@/components/layout";
import { EmailList } from "../components/emailList";

export function EmailListPage() {
  return (
    <Layout>
      <div className="w-full h-[calc(100vh-170px)] grid grid-cols-1 md:grid-cols-5">
        <div className="col-span-1 md:col-span-3 p-3 overflow-y-auto">
          <EmailList />
        </div>
        <div className="col-span-1 md:col-span-2 p-3 bg-blue-900"></div>
      </div>
    </Layout>
  );
}

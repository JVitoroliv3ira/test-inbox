import { Header } from './header';
import { Footer } from './footer';

export function Layout({ children }: { children: React.ReactNode }) {
  return (
    <div className="flex flex-col min-h-screen bg-background text-foreground">
      <Header />
      <main className="flex-1 w-full p-4">
        {children}
      </main>
      <Footer />
    </div>
  );
}
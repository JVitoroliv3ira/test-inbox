export function Footer() {
  return (
    <footer className="w-full border-t bg-background text-muted-foreground">
      <div className="container mx-auto px-4 py-4 text-sm text-center">
        &copy; {new Date().getFullYear()} TestInbox –{" "}
        <a
          href="https://github.com/JVitoroliv3ira/test-inbox/blob/main/LICENSE"
          target="_blank"
          rel="noopener noreferrer"
          className="underline"
        >
          MIT License
        </a>
      </div>
    </footer>
  );
}

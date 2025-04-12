import { BrowserRouter, Route, Routes } from "react-router-dom"
import { EmailListPage } from "./features/email/pages/EmailListPage"
import { EmailDetailPage } from "./features/email/pages/EmailDetailPage"

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<EmailListPage />} />
        <Route path="/email/:id" element={<EmailDetailPage />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App

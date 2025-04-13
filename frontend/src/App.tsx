import { BrowserRouter, Route, Routes } from "react-router-dom"
import { EmailListPage } from "./features/email/pages/EmailListPage"

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<EmailListPage />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App

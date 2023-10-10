import './App.css'
import SignIn from "./Pages/SignIn/SignIn.jsx";
import {RouterProvider} from "react-router";
import {createBrowserRouter} from "react-router-dom"
import Root from "./Pages/Root/Root.jsx";

// Something is happening where Root is blocking Sign In
const router = createBrowserRouter([{
  path: "/app/",
  element: <SignIn />,
  children: [{
    path: "SignIn",
    element: <SignIn />
  }]
}])

function App() {

  return (
      <RouterProvider router={router} />
  )
}

export default App

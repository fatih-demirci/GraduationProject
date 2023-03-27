import Home from "./components/Home";
// import env from "dotenv"

function App() {
  // console.log(process.env.NODE_ENV);
  console.log(process.env.REACT_APP_API_URL);

  return (
    <div className="App">
      {process.env.REACT_APP_API_URL}
     <Home/>

    </div>
  );
}

export default App;

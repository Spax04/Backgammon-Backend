import { getAllByText } from '@testing-library/react'
import React, { useState,useEffect } from 'react'

function App () {

  const [alex,setAlex] = useState({});

  const getAllByText= ()=>{
    const url = "http://localhost:5032/api/Test"
    fetch(url,{
    }).then(response => response.json()).then(postFormServer =>{
      setAlex(postFormServer);
      console.log(postFormServer);
    });
  }

  useEffect(()=>{
    getAllByText()
  },[])
  
  return (
    <div >
      <h1>Test</h1>
      <p>{alex.id}</p>
      <p>{alex.name}</p>
      <p>{alex.age}</p>
    </div>
  )
}

export default App

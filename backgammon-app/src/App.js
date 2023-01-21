import { getAllByText } from '@testing-library/react'
import React, { useState,useEffect } from 'react'
import Chat from './components/Chat/Chat';

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
      
    </div>
  )
}

export default App

import React from 'react'

import '../SideBar.css'

const Input = () => {
  return (
    <div className='input'>
      <input type="text" placeholder='Type something...' />
      <div className="send">
        <img src="https://cdn-icons-png.flaticon.com/128/9195/9195525.png" alt="" id="attach"/>
        <input type="file" style={{display:"none"}} />
        <label htmlFor='file'>
          <img src="https://cdn-icons-png.flaticon.com/128/8191/8191568.png" alt="" />
        </label>
        <button>Send</button>
      </div>
    </div>
  )
}
export default Input
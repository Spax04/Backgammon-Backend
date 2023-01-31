import React from 'react'

const Search = () => {
  return (
    <div>
      <div className="serchForm">
        <input type="text"
        placeholder='Find a user'
         id='searchInput'/>
      </div>
      <div className='userChat'>
        <img src="https://i.pinimg.com/736x/52/e4/ff/52e4ff859d7159aaeb3a71e65fea34f2.jpg" alt="" />
        <div className='userChatInfo'>
          <span>Daniel</span>
        </div>
      </div>
    </div>
  )
}

export default Search
import React from 'react';

import TechSupportForm from './views/TechSupportForm';

import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';

library.add(faSpinner);

const App: React.FC = () => {
  return (
    <div className="container">
      <h1>Tech Support</h1>
      <TechSupportForm/>
    </div>
  );
};

export default App;

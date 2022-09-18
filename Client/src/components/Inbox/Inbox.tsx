import React, { FC } from 'react';
import styles from './Inbox.module.css';

interface InboxProps {}

const Inbox: FC<InboxProps> = () => (
  <div className={styles.InboxIcon} data-testid="Inbox">
    All incoming space allocation request coming here!
  </div>
);

export default Inbox;

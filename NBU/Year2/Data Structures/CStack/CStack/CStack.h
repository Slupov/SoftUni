#ifndef CITB306G1_CSTACK
#define CITB306G1_CSTACK

#include "CLinkedList.h"
#include "CExceptions.h"

#define CSTACK_MAX_CAP 12

class CStack : private CLinkedList {
public:
    CStack() {
        m_nCap = CSTACK_MAX_CAP;
        m_nCount = 0;
    }

    CStack(int cap) {
        m_nCap = cap;
        m_nCount = 0;
    }

    void push(CNode* pNewNode) throw (CExceptionStackOverflow);
    CNode* pop() throw (CExceptionEmptyStack);
    void trace() const;


    int write_file_from_linked_list(char* file_name);
    int read_from_file_to_linked_list(char* file_name);


private:
    int m_nCap;
    int m_nCount;
};

#endif // CITB306G1_CSTACK

